using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazo
{
    private List<Carta> cartas = new List<Carta>();

    public void CrearMazo()
    {
        cartas.Clear();

        foreach (Palo palo in System.Enum.GetValues(typeof(Palo)))
        {
            for (int numero = 1; numero <= 12; numero++)
            {
                if (numero == 8 || numero == 9) continue;

                int jerarquia = ObtenerJerarquia(numero, palo);
                cartas.Add(new Carta(numero, palo, jerarquia));
            }
        }
    }

    int ObtenerJerarquia(int numero, Palo palo)
    {
        if (numero == 1 && palo == Palo.Espada) return 1;
        if (numero == 1 && palo == Palo.Basto) return 2;
        if (numero == 7 && palo == Palo.Espada) return 3;
        if (numero == 7 && palo == Palo.Oro) return 4;

        if (numero == 3) return 5;
        if (numero == 2) return 6;
        if (numero == 1) return 7;
        if (numero == 12) return 8;
        if (numero == 11) return 9;
        if (numero == 10) return 10;
        if (numero == 7) return 11;
        if (numero == 6) return 12;
        if (numero == 5) return 13;
        return 14; // 4
    }

    public void Mezclar()
    {
        for (int i = 0; i < cartas.Count; i++)
        {
            int rnd = Random.Range(i, cartas.Count);
            (cartas[i], cartas[rnd]) = (cartas[rnd], cartas[i]);
        }
    }

    public Carta RobarCarta()
    {
        Carta carta = cartas[0];
        cartas.RemoveAt(0);
        return carta;
    }
}