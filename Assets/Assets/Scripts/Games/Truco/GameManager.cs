using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private Mazo mazo;
    private Jugador jugador;
    private Jugador ia;

    // Rondas
    private int rondasJugador;
    private int rondasIA;

    // Puntaje total
    private int puntosJugador;
    private int puntosIA;

    // Mano
    private bool manoJugador;
    private bool primeraMano = true;
    private int ganadorPrimeraRonda;
    private bool huboPardaPrimera;
    private int cartasJugadasPrimeraRonda;

    // Mesa
    private Carta cartaJugadorMesa;
    private Carta cartaIAMesa;

    // Truco (básico)
    private int nivelTruco;

    // ================= ENVIDO =================
    private bool envidoEnCurso;
    private int puntosEnvidoEnJuego;
    private int cantosEnvido; // cantidad de cantos hechos
    private TipoEnvido tipoEnvidoActual;

    enum TipoEnvido
    {
        Ninguno,
        Envido,
        RealEnvido,
        FaltaEnvido
    }

    void Start()
    {
        mazo = new Mazo();
        jugador = new Jugador("Jugador");
        ia = new Jugador("IA");

        puntosJugador = 0;
        puntosIA = 0;

        IniciarMano();
    }

    void Update()
    {
        if (envidoEnCurso) return;
        if (cartaJugadorMesa != null) return;

        if (Input.GetKeyDown(KeyCode.Alpha1)) JugarCartaJugador(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) JugarCartaJugador(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) JugarCartaJugador(3);
    }

    // ================= MANO =================

    void IniciarMano()
    {
        rondasJugador = 0;
        rondasIA = 0;
        ganadorPrimeraRonda = 0;
        huboPardaPrimera = false;
        cartasJugadasPrimeraRonda = 0;

        cartaJugadorMesa = null;
        cartaIAMesa = null;

        nivelTruco = 0;

        // ENVIDO RESET
        envidoEnCurso = false;
        puntosEnvidoEnJuego = 0;
        cantosEnvido = 0;
        tipoEnvidoActual = TipoEnvido.Ninguno;

        jugador.LimpiarMano();
        ia.LimpiarMano();

        mazo.CrearMazo();
        mazo.Mezclar();

        for (int i = 0; i < 3; i++)
        {
            jugador.RecibirCarta(mazo.RobarCarta());
            ia.RecibirCarta(mazo.RobarCarta());
        }

        if (primeraMano)
        {
            manoJugador = Random.value > 0.5f;
            primeraMano = false;
        }
        else
        {
            manoJugador = !manoJugador;
        }

        Debug.Log("================================");
        Debug.Log("🆕 NUEVA MANO");
        Debug.Log(manoJugador ? "👉 Jugador es MANO" : "🤖 IA es MANO");

        MostrarCartasJugador();

        if (!manoJugador)
            EvaluarEnvidoIA();
    }

    // ================= ENVIDO =================

    public void CantarEnvido()
    {
        if (!EsPrimeraRonda() || envidoEnCurso) return;

        envidoEnCurso = true;
        tipoEnvidoActual = TipoEnvido.Envido;
        puntosEnvidoEnJuego = 2;
        cantosEnvido = 1;

        Debug.Log("🗣️ JUGADOR canta ENVIDO");

        ResponderEnvidoIA();
    }

    public void CantarRealEnvido()
    {
        if (!envidoEnCurso) return;

        tipoEnvidoActual = TipoEnvido.RealEnvido;
        puntosEnvidoEnJuego += 3;
        cantosEnvido++;

        Debug.Log("🗣️ JUGADOR canta REAL ENVIDO");

        ResponderEnvidoIA();
    }

    public void CantarFaltaEnvido()
    {
        if (!envidoEnCurso) return;

        tipoEnvidoActual = TipoEnvido.FaltaEnvido;
        cantosEnvido++;

        Debug.Log("🗣️ JUGADOR canta FALTA ENVIDO");

        ResponderEnvidoIA();
    }

    void EvaluarEnvidoIA()
    {
        int eIA = ia.CalcularEnvido();

        if (eIA >= 20 && EsPrimeraRonda())
        {
            envidoEnCurso = true;
            tipoEnvidoActual = TipoEnvido.Envido;
            puntosEnvidoEnJuego = 2;
            cantosEnvido = 1;

            Debug.Log($"🤖 IA canta ENVIDO (tiene {eIA})");

            ResolverEnvido();
        }
    }

    void ResponderEnvidoIA()
    {
        int eIA = ia.CalcularEnvido();
        Debug.Log($"🤖 Envido IA: {eIA}");

        if (eIA >= 20)
        {
            Debug.Log("🤖 IA QUIERE");
            ResolverEnvido();
        }
        else
        {
            Debug.Log("🤖 IA NO QUIERE");
            NoQuisoEnvido(2);
        }
    }

    void ResolverEnvido()
    {
        int eJugador = jugador.CalcularEnvido();
        int eIA = ia.CalcularEnvido();

        Debug.Log($"🧮 Envido Jugador: {eJugador}");
        Debug.Log($"🧮 Envido IA: {eIA}");

        int ganador =
            eJugador > eIA ? 1 :
            eIA > eJugador ? 2 :
            manoJugador ? 1 : 2;

        int puntos;

        if (tipoEnvidoActual == TipoEnvido.FaltaEnvido)
        {
            puntos = 15 - (ganador == 1 ? puntosJugador : puntosIA);
        }
        else
        {
            puntos = puntosEnvidoEnJuego;
        }

        if (ganador == 1) puntosJugador += puntos;
        else puntosIA += puntos;

        Debug.Log($"🏆 ENVIDO para {(ganador == 1 ? "Jugador" : "IA")} (+{puntos})");
        Debug.Log($"📊 PUNTOS → Jugador {puntosJugador} | IA {puntosIA}");

        IniciarMano();
    }

    void NoQuisoEnvido(int quienNoQuiso)
    {
        int ganador = quienNoQuiso == 1 ? 2 : 1;
        int puntos = cantosEnvido;

        if (ganador == 1) puntosJugador += puntos;
        else puntosIA += puntos;

        Debug.Log($"🚪 {(quienNoQuiso == 1 ? "Jugador" : "IA")} NO QUIERE (+{puntos})");
        Debug.Log($"📊 PUNTOS → Jugador {puntosJugador} | IA {puntosIA}");

        IniciarMano();
    }

    // ================= CARTAS =================

    void JugarCartaJugador(int numeroTecla)
    {
        int index = numeroTecla - 1;
        if (index < 0 || index >= jugador.mano.Count) return;

        cartaJugadorMesa = jugador.JugarCarta(index);
        cartasJugadasPrimeraRonda++;

        Debug.Log($"🃏 Jugador juega [{numeroTecla}]: {cartaJugadorMesa}");

        if (cartaIAMesa == null)
            JugarCartaIA();

        ResolverRonda();
    }

    void JugarCartaIA()
    {
        cartaIAMesa = ia.JugarCartaIA();
        Debug.Log($"🤖 IA juega: {cartaIAMesa}");
    }

    // ================= RONDAS =================

    void ResolverRonda()
    {
        if (cartaJugadorMesa.jerarquia < cartaIAMesa.jerarquia) GanaRonda(1);
        else if (cartaJugadorMesa.jerarquia > cartaIAMesa.jerarquia) GanaRonda(2);
        else Parda();

        cartaJugadorMesa = null;
        cartaIAMesa = null;

        if (!VerificarFinMano() && !manoJugador)
            JugarCartaIA();
    }

    void GanaRonda(int ganador)
    {
        if (rondasJugador + rondasIA == 0)
            ganadorPrimeraRonda = ganador;

        if (ganador == 1)
        {
            rondasJugador++;
            manoJugador = true;
            Debug.Log("✅ Ronda Jugador");
        }
        else
        {
            rondasIA++;
            manoJugador = false;
            Debug.Log("❌ Ronda IA");
        }
    }

    void Parda()
    {
        Debug.Log("⚖️ PARDA");

        if (rondasJugador + rondasIA == 0)
            huboPardaPrimera = true;
        else if (huboPardaPrimera)
            GanaMano(manoJugador ? 1 : 2);
        else
            GanaMano(ganadorPrimeraRonda);
    }

    bool VerificarFinMano()
    {
        if (rondasJugador == 2) { GanaMano(1); return true; }
        if (rondasIA == 2) { GanaMano(2); return true; }
        return false;
    }

    void GanaMano(int ganador)
    {
        int puntos = nivelTruco == 0 ? 1 : nivelTruco + 1;

        if (ganador == 1) puntosJugador += puntos;
        else puntosIA += puntos;

        Debug.Log($"🏆 MANO {(ganador == 1 ? "Jugador" : "IA")} (+{puntos})");
        Debug.Log($"📊 PUNTOS → Jugador {puntosJugador} | IA {puntosIA}");

        IniciarMano();
    }

    // ================= DEBUG =================

    void MostrarCartasJugador()
    {
        Debug.Log("🃏 CARTAS DEL JUGADOR:");
        for (int i = 0; i < jugador.mano.Count; i++)
            Debug.Log($"[{i + 1}] {jugador.mano[i]}");
    }

    // ================= GETTERS =================

    public Jugador GetJugador() => jugador;
    public Jugador GetIA() => ia;
    public bool EsManoJugador() => manoJugador;
    public bool EsPrimeraRonda() => rondasJugador + rondasIA == 0;
    public int GetPuntosJugador() => puntosJugador;
    public int GetPuntosIA() => puntosIA;

}


