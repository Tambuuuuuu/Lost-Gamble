using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Palo
{
    Espada,
    Basto,
    Oro,
    Copa
}

public class Carta
{
    public int numero;
    public Palo palo;        // 👈 enum, NO string
    public int jerarquia;
    public int valor;        // para envido

    public Carta(int numero, Palo palo, int jerarquia)
    {
        this.numero = numero;
        this.palo = palo;
        this.jerarquia = jerarquia;

        // Valor de envido
        if (numero >= 10)
            valor = 0;
        else
            valor = numero;
    }

    public override string ToString()
    {
        return $"{numero} de {palo}";
    }
}