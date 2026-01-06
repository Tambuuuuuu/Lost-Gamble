using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class Puntaje : MonoBehaviour
{
    DadoPlayer dadoPlayer;
    DadoEnemigo dadoEnemigo;

    public  TextMeshProUGUI scorePlayer;
    public TextMeshProUGUI scoreEnemy;

    private void Awake()
    {
        dadoPlayer = FindAnyObjectByType<DadoPlayer>();
        dadoEnemigo = FindAnyObjectByType<DadoEnemigo>();
    }
    private void Update()
    {
        
        if (dadoPlayer != null)
        {
            if (dadoPlayer.dicefacenum != 0)
            {
                scorePlayer.text = dadoPlayer.dicefacenum.ToString();

            }
        }
        if (dadoEnemigo != null)
        {
            if (dadoEnemigo.dicefacenum != 0)
            {
                scoreEnemy.text = dadoEnemigo.dicefacenum.ToString();

            }
        }
    }
}