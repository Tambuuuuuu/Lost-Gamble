using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCanto : MonoBehaviour
{
    public GameObject panelOpciones;

    public void Toggle()
    {
        panelOpciones.SetActive(!panelOpciones.activeSelf);
    }
}
