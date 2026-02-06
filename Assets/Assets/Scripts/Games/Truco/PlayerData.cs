using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string nombre;
    public List<Carta> cartas = new List<Carta>();
    public int puntos;

    public PlayerData(string nombre)
    {
        this.nombre = nombre;
        puntos = 0;
    }

}
