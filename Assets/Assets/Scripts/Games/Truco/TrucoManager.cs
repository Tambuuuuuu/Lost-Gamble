using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrucoManager : MonoBehaviour
{
    private GameManager game;

    private int nivelTruco; // 0 a 3
    private bool trucoEnCurso;

    public void Init(GameManager gm)
    {
        game = gm;
        Resetear();
    }

    public void Resetear()
    {
        nivelTruco = 0;
        trucoEnCurso = false;
    }

    public void CantarTruco()
    {
        if (nivelTruco >= 3) return;

        nivelTruco++;
        trucoEnCurso = true;

        Debug.Log("🗣️ " + NombreTruco());
    }

    public void Quiero()
    {
        trucoEnCurso = false;
        Debug.Log("✅ Truco aceptado");
    }

    public void NoQuiero()
    {
        Debug.Log("❌ No quiso el truco");
        game.Invoke("IniciarMano", 0.5f);
    }

    public int GetPuntos()
    {
        return nivelTruco == 0 ? 1 : nivelTruco + 1;
    }

    string NombreTruco()
    {
        return nivelTruco == 1 ? "TRUCO" :
               nivelTruco == 2 ? "RETRUCO" :
               "VALE CUATRO";
    }
}

