using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repartidor : MonoBehaviour
{
    public GameObject cartaPrefab;

    public Transform[] posicionesJugador;
    public Transform[] posicionesIA;

    private Mazo mazo;

    void Start()
    {
        mazo = new Mazo();
        mazo.CrearMazo();
        mazo.Mezclar();

        Repartir();
    }

    void Repartir()
    {
        for (int i = 0; i < 3; i++)
        {
            // Jugador
            CrearCarta(mazo.RobarCarta(), posicionesJugador[i]);

            // IA
            CrearCarta(mazo.RobarCarta(), posicionesIA[i]);
        }
    }

    void CrearCarta(Carta carta, Transform posicion)
    {
        GameObject obj = Instantiate(cartaPrefab);

        obj.transform.SetParent(posicion);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;

    }

}
