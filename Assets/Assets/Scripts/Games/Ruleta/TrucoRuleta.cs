using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*public class TrucoRuleta : MonoBehaviour
{
    /*public Ruleta ruleta;
    public Button[] botonesColores; 

    private bool trucoActivado = false;
    private bool usado = false;

    private void Start()
    {
        foreach (Button botonColor in botonesColores)
        {
            botonColor.interactable = false;
        }
    }

    void Update()
    {
        // Activar el truco al presionar la tecla "E"
        if (Input.GetKeyDown(KeyCode.E) && !trucoActivado && usado != true)
        {
            ActivarTruco();
        }
        // Desactivar el truco al presionar la tecla "E" nuevamente
        else if (Input.GetKeyDown(KeyCode.E) && trucoActivado && usado != true)
        {
            DesactivarTruco();
        }
    }

    public void ActivarTruco()
    {
        trucoActivado = true;
        // Mostrar los botones de colores
        foreach (GameObject botonColor in botonesColores)
        {
            botonColor.SetActive(true);
        }
    }

    void DesactivarTruco()
    {
        trucoActivado = false;
        // Ocultar los botones de colores
        foreach (GameObject botonColor in botonesColores)
        {
            botonColor.SetActive(false);
        }
    }

    // Método para seleccionar un color y activar el truco en la ruleta
    public void SeleccionarColor(int colorIndex)
    {
        if (ruleta != null && trucoActivado)
        {
            ruleta.ActivarTruco(colorIndex);
            DesactivarTruco(); // Desactivar el truco después de seleccionar un color
            usado = true;
        }
    }
}*/
