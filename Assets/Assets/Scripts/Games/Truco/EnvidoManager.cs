using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvidoManager : MonoBehaviour
{
    private GameManager game;

    private bool envidoResuelto;
    private int puntosEnvidoEnJuego;
    private bool esFaltaEnvido;

    public void Init(GameManager gm)
    {
        game = gm;
        Resetear();
    }

    public void Resetear()
    {
        envidoResuelto = false;
        puntosEnvidoEnJuego = 0;
        esFaltaEnvido = false;
    }

    public bool PuedeCantarEnvido(int cartasJugadas)
    {
        return !envidoResuelto &&
               game.EsPrimeraRonda() &&
               cartasJugadas < 2;
    }

    public void CantarEnvido()
    {
        puntosEnvidoEnJuego += 2;
        Debug.Log("🗣️ ENVIDO");
    }

    public void CantarRealEnvido()
    {
        puntosEnvidoEnJuego += 3;
        Debug.Log("🗣️ REAL ENVIDO");
    }

    public void CantarFaltaEnvido()
    {
        esFaltaEnvido = true;
        Debug.Log("🗣️ FALTA ENVIDO");
    }

    public void Quiero()
    {
        int ej = game.GetJugador().CalcularEnvido();
        int ei = game.GetIA().CalcularEnvido();

        int ganador =
            ej > ei ? 1 :
            ei > ej ? 2 :
            game.EsManoJugador() ? 1 : 2;

        int puntos = esFaltaEnvido
            ? 15 - (ganador == 1 ? game.GetPuntosJugador() : game.GetPuntosIA())
            : puntosEnvidoEnJuego;

        Debug.Log($"🏆 Envido ganado por {(ganador == 1 ? "Jugador" : "IA")} (+{puntos})");

        envidoResuelto = true;
    }

    public void NoQuiero()
    {
        Debug.Log("❌ No quiso el envido (+1)");
        envidoResuelto = true;
    }
}


