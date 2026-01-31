using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dectector_Numeros : MonoBehaviour
{
    DadoPlayer dadoPlayer;
    DadoEnemigo dadoEnemigo;
    private void Awake()
    {
        dadoPlayer = FindAnyObjectByType<DadoPlayer>();
        dadoEnemigo = FindAnyObjectByType<DadoEnemigo>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("playerDice") || other.CompareTag("CaraFake"))
        {
            if(dadoPlayer != null)
            {
                if (dadoPlayer.GetComponent<Rigidbody>().velocity == Vector3.zero)
                {
                    dadoPlayer.dicefacenum = int.Parse(other.name);
                }
            } 
        }
        if (other.CompareTag("enemyDice") || other.CompareTag("EnemyFake"))
        {
            if(dadoEnemigo != null)
            {
                if (dadoEnemigo.GetComponent<Rigidbody>().velocity == Vector3.zero)
                {
                    dadoEnemigo.dicefacenum = int.Parse(other.name);
                }
            } 
        }
    }
}