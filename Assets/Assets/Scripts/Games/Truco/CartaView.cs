using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaView : MonoBehaviour
{
    [Header("Datos de la carta")]
    public int numero;
    public Palo palo;
    public int jerarquia;
    public int valorEnvido;

    private void OnMouseDown()
    {
        Debug.Log($"🃏 Carta tocada: {numero} de {palo} | Jerarquía: {jerarquia} | Envido: {valorEnvido}");
    }

}
