using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvidoManager : MonoBehaviour
{
    private GameManager game;

    private bool envidoEnCurso;
    private bool envidoResuelto;

    private int puntosEnvidoEnJuego;
    private bool esFaltaEnvido;

    // 1 = jugador | 2 = IA
    private int quienCanto;

    public EnvidoManager(GameManager gm)
    {
        game = gm;
        Resetear();
    }

    public void Resetear()
    {
        envidoEnCurso = false;
        envidoResuelto = false;
        puntosEnvidoEnJuego = 0;
        esFaltaEnvido = false;
        quienCanto = 0;
    }

    // =============================
    // VALIDACIÓN
    // =============================
    public bool PuedeCantarEnvido(int cartasJugadasPrimeraRonda)
    {
        return !envidoResuelto &&
               game.EsPrimeraRonda() &&
               cartasJugadasPrimeraRonda < 2;
    }

    // =============================
    // CANTOS
    // =============================
    public void CantarEnvido(int quien)
    {
        envidoEnCurso = true;
        quienCanto = quien;
        puntosEnvidoEnJuego += 2;

        Debug.Log("🗣️ ENVIDO");
    }

    public void CantarRealEnvido(int quien)
    {
        envidoEnCurso = true;
        quienCanto = quien;
        puntosEnvidoEnJuego += 3;

        Debug.Log("🗣️ REAL ENVIDO");
    }

    public void CantarFaltaEnvido(int quien)
    {
        envidoEnCurso = true;
        quienCanto = quien;
        esFaltaEnvido = true;

        Debug.Log("🗣️ FALTA ENVIDO");
    }

    // =============================
    // RESPUESTAS
    // =============================
    public void NoQuiero()
    {
        if (quienCanto == 1)
            SumarPuntosJugador(1);
        else
            SumarPuntosIA(1);

        envidoResuelto = true;

        Debug.Log("❌ No quiso el envido (+1)");
    }

    public void Quiero()
    {
        int envidoJugador = CalcularEnvido(game.GetJugador().mano);
        int envidoIA = CalcularEnvido(game.GetIA().mano);

        int ganador;

        if (envidoJugador > envidoIA)
            ganador = 1;
        else if (envidoIA > envidoJugador)
            ganador = 2;
        else
            ganador = game.EsManoJugador() ? 1 : 2;

        int puntos;

        if (esFaltaEnvido)
        {
            puntos = ganador == 1
                ? 15 - ObtenerPuntosJugador()
                : 15 - ObtenerPuntosIA();
        }
        else
        {
            puntos = puntosEnvidoEnJuego;
        }

        if (ganador == 1)
            SumarPuntosJugador(puntos);
        else
            SumarPuntosIA(puntos);

        envidoResuelto = true;

        Debug.Log($"🏆 Envido ganado por {(ganador == 1 ? "Jugador" : "IA")} (+{puntos})");
    }

    // =============================
    // CÁLCULO DE ENVIDO
    // =============================
    private int CalcularEnvido(List<Carta> mano)
    {
        int mejor = 0;

        for (int i = 0; i < mano.Count; i++)
        {
            for (int j = i + 1; j < mano.Count; j++)
            {
                if (mano[i].palo == mano[j].palo)
                {
                    int v1 = ValorEnvido(mano[i]);
                    int v2 = ValorEnvido(mano[j]);
                    mejor = Mathf.Max(mejor, v1 + v2 + 20);
                }
            }
        }

        // Si no hubo palo
        if (mejor == 0)
        {
            foreach (var c in mano)
                mejor = Mathf.Max(mejor, ValorEnvido(c));
        }

        return mejor;
    }

    private int ValorEnvido(Carta c)
    {
        // 10, 11, 12 valen 0
        return c.numero <= 7 ? c.numero : 0;
    }

    // =============================
    // PUNTOS (sin romper encapsulación)
    // =============================
    private void SumarPuntosJugador(int p)
    {
        typeof(GameManager)
            .GetField("puntosJugador", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(game, ObtenerPuntosJugador() + p);
    }

    private void SumarPuntosIA(int p)
    {
        typeof(GameManager)
            .GetField("puntosIA", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(game, ObtenerPuntosIA() + p);
    }

    private int ObtenerPuntosJugador()
    {
        return (int)typeof(GameManager)
            .GetField("puntosJugador", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(game);
    }

    private int ObtenerPuntosIA()
    {
        return (int)typeof(GameManager)
            .GetField("puntosIA", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(game);
    }

}

