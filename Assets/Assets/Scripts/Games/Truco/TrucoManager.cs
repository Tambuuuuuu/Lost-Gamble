using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrucoManager : MonoBehaviour
{
    private GameManager game;

    public int nivelTruco; // 0 a 3
    public bool trucoEnCurso;
    public bool trucoAceptado;

    public PlayerData quienCanto;

    public TrucoManager(GameManager game)
    {
        this.game = game;
    }

    public void Resetear()
    {
        nivelTruco = 0;
        trucoEnCurso = false;
        trucoAceptado = false;
        quienCanto = null;
    }

    public void CantarTruco(PlayerData jugador)
    {
        if (nivelTruco < 3)
        {
            nivelTruco++;
            trucoEnCurso = true;
            quienCanto = jugador;

            Debug.Log(jugador.nombre + " canta " + NombreTruco());
        }
    }

    public void Quiero()
    {
        trucoAceptado = true;
        trucoEnCurso = false;
        Debug.Log("Truco aceptado: vale " + ValorActual());
    }

    public void NoQuiero()
    {
        int puntos = ValorActual() - 1;
        quienCanto.puntos += puntos;

        Debug.Log("No quiso el truco, " + quienCanto.nombre + " suma " + puntos);
        game.NuevaMano();
    }

    public int ValorActual()
    {
        return nivelTruco == 0 ? 1 : nivelTruco + 1;
    }

    string NombreTruco()
    {
        switch (nivelTruco)
        {
            case 1: return "TRUCO";
            case 2: return "RETRUCO";
            case 3: return "VALE CUATRO";
        }
        return "";
    }

}
