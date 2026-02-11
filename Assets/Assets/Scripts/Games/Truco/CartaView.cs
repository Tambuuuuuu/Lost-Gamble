using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaView : MonoBehaviour
{
    [Header("Modelo")]
    public Carta carta;

    [Header("Debug Inspector")]
    [SerializeField] private int numero;
    [SerializeField] private Palo palo;
    [SerializeField] private int jerarquia;
    [SerializeField] private int valorEnvido;

    private GameManager game;

    public void Inicializar(Carta nuevaCarta, GameManager gm)
    {
        carta = nuevaCarta;
        game = gm;

        numero = carta.numero;
        palo = carta.palo;
        jerarquia = carta.jerarquia;
        valorEnvido = carta.valor;
    }

    private void OnMouseDown()
    {
        if (carta == null) return;

      //  game.JugarCartaDesdeView(this);
    }
}