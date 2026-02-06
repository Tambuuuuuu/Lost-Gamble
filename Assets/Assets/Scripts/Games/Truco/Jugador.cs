using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador
{
    public string nombre;
    public List<Carta> mano = new List<Carta>();

    public Jugador(string nombre)
    {
        this.nombre = nombre;
    }

    public void RecibirCarta(Carta carta)
    {
        mano.Add(carta);
    }

    public void LimpiarMano()
    {
        mano.Clear();
    }

    public Carta JugarCarta(int index)
    {
        Carta carta = mano[index];
        mano.RemoveAt(index);
        return carta;
    }

    public Carta JugarCartaIA()
    {
        Carta carta = mano[0];
        mano.RemoveAt(0);
        return carta;
    }

    // ==========================
    // ENVIDO
    // ==========================
    public int CalcularEnvido()
    {
        int maxEnvido = 0;

        for (int i = 0; i < mano.Count; i++)
        {
            for (int j = i + 1; j < mano.Count; j++)
            {
                if (mano[i].palo == mano[j].palo)
                {
                    int suma = mano[i].valor + mano[j].valor + 20;
                    if (suma > maxEnvido)
                        maxEnvido = suma;
                }
            }
        }

        // Si no hay palo repetido
        if (maxEnvido == 0)
        {
            foreach (Carta c in mano)
            {
                if (c.valor > maxEnvido)
                    maxEnvido = c.valor;
            }
        }

        return maxEnvido;
    }
}

