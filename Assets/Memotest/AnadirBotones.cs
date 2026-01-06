using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnadirBotones : MonoBehaviour
{
    [SerializeField]
    private Transform Escenario;

    [SerializeField]
    private GameObject botones;


    private void Awake()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject boton = Instantiate(botones);
            boton.name = "" + i;
            boton.transform.SetParent(Escenario, false);

        }

    }
}
