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
    private int ganadorPrimeraRonda;
    private bool huboPardaPrimera;

    // Mesa
    private Carta cartaJugadorMesa;
    private Carta cartaIAMesa;

    // Envido
    private bool envidoEnCurso;
    private bool envidoResuelto;
    private int puntosEnvidoEnJuego;
    private bool esFaltaEnvido;
    private int jugadorQueCantoEnvido;

    // Truco
    private int nivelTruco; // 0 a 3
    private bool trucoEnCurso;
    private bool trucoAceptado;
    private int jugadorQueCantoTruco;

    private int cartasJugadasPrimeraRonda;

    void Start()
    {
        mazo = new Mazo();
        jugador = new Jugador("Jugador");
        ia = new Jugador("IA");

        puntosJugador = 0;
        puntosIA = 0;

        IniciarMano();
    }

    void IniciarMano()
    {
        rondasJugador = 0;
        rondasIA = 0;

        ganadorPrimeraRonda = 0;
        huboPardaPrimera = false;

        cartaJugadorMesa = null;
        cartaIAMesa = null;

        envidoEnCurso = false;
        envidoResuelto = false;
        puntosEnvidoEnJuego = 0;
        esFaltaEnvido = false;

        nivelTruco = 0;
        trucoEnCurso = false;
        trucoAceptado = false;

        cartasJugadasPrimeraRonda = 0;

        manoJugador = Random.value > 0.5f;

        jugador.LimpiarMano();
        ia.LimpiarMano();

        mazo.CrearMazo();
        mazo.Mezclar();

        for (int i = 0; i < 3; i++)
        {
            jugador.RecibirCarta(mazo.RobarCarta());
            ia.RecibirCarta(mazo.RobarCarta());
        }

        Debug.Log("---- NUEVA MANO ----");
        Debug.Log(manoJugador ? "Jugador es MANO" : "IA es MANO");

        if (!manoJugador)
            JugarCartaIA();

        MostrarCartasJugador();
    }

    void Update()
    {
        if (cartaJugadorMesa == null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) JugarCartaJugador(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) JugarCartaJugador(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) JugarCartaJugador(2);
        }

        if (PuedeCantarEnvido())
        {
            if (Input.GetKeyDown(KeyCode.E)) CantarEnvido(1);
            if (Input.GetKeyDown(KeyCode.R)) CantarRealEnvido(1);
            if (Input.GetKeyDown(KeyCode.F)) CantarFaltaEnvido(1);
        }

        if (Input.GetKeyDown(KeyCode.T)) CantarTruco(1);
    }

    bool PuedeCantarEnvido()
    {
        return !envidoResuelto &&
               rondasJugador + rondasIA == 0 &&
               cartasJugadasPrimeraRonda < 2;
    }

    void CantarEnvido(int quien)
    {
        envidoEnCurso = true;
        jugadorQueCantoEnvido = quien;
        puntosEnvidoEnJuego += 2;
        Debug.Log("ENVIDO");
    }

    void CantarRealEnvido(int quien)
    {
        envidoEnCurso = true;
        jugadorQueCantoEnvido = quien;
        puntosEnvidoEnJuego += 3;
        Debug.Log("REAL ENVIDO");
    }

    void CantarFaltaEnvido(int quien)
    {
        envidoEnCurso = true;
        jugadorQueCantoEnvido = quien;
        esFaltaEnvido = true;
        Debug.Log("FALTA ENVIDO");
    }

    void ResolverEnvido()
    {
        int eJugador = jugador.CalcularEnvido();
        int eIA = ia.CalcularEnvido();

        int ganador =
            eJugador > eIA ? 1 :
            eIA > eJugador ? 2 :
            (manoJugador ? 1 : 2);

        int puntos = esFaltaEnvido
            ? 15 - (ganador == 1 ? puntosJugador : puntosIA)
            : puntosEnvidoEnJuego;

        if (ganador == 1) puntosJugador += puntos;
        else puntosIA += puntos;

        envidoResuelto = true;
        Debug.Log("Envido ganado por " + (ganador == 1 ? "Jugador" : "IA"));
    }
    public void NuevaMano()
    {
        IniciarMano();
    }

    void CantarTruco(int quien)
    {
        if (nivelTruco < 3)
        {
            nivelTruco++;
            trucoEnCurso = true;
            jugadorQueCantoTruco = quien;

            Debug.Log(nivelTruco == 1 ? "TRUCO" :
                      nivelTruco == 2 ? "RETRUCO" :
                                        "VALE CUATRO");
        }
    }

    void JugarCartaJugador(int index)
    {
        if (index >= jugador.mano.Count) return;

        cartaJugadorMesa = jugador.JugarCarta(index);
        cartasJugadasPrimeraRonda++;
        Debug.Log("Jugador juega: " + cartaJugadorMesa);

        if (cartaIAMesa == null)
            JugarCartaIA();

        ResolverRonda();
    }

    void JugarCartaIA()
    {
        cartaIAMesa = ia.JugarCartaIA();
        cartasJugadasPrimeraRonda++;
        Debug.Log("IA juega: " + cartaIAMesa);
    }

    void ResolverRonda()
    {
        if (cartaJugadorMesa == null || cartaIAMesa == null) return;

        if (cartaJugadorMesa.jerarquia < cartaIAMesa.jerarquia)
            GanaRonda(1);
        else if (cartaJugadorMesa.jerarquia > cartaIAMesa.jerarquia)
            GanaRonda(2);
        else
            Parda();

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
        }
        else
        {
            rondasIA++;
            manoJugador = false;
        }
    }

    void Parda()
    {
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

        Debug.Log("Mano ganada por " + (ganador == 1 ? "Jugador" : "IA"));

        IniciarMano();
    }

    void MostrarCartasJugador()
    {
        for (int i = 0; i < jugador.mano.Count; i++)
            Debug.Log($"{i}: {jugador.mano[i]}");
    }
    public Jugador GetJugador() => jugador;
    public Jugador GetIA() => ia;
    public bool EsManoJugador() => manoJugador;

    // Primera ronda = todavía no se ganó ninguna ronda
    public bool EsPrimeraRonda()
    {
        return rondasJugador + rondasIA == 0;
    }

}

