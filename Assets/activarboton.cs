using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarboton : MonoBehaviour
{
    public GameObject button; // Asigna el botón desde el inspector

    void Start()
    {
        button.SetActive(false); // Asegúrate de que el botón esté desactivado al inicio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el objeto tenga el tag "Player" o el que prefieras
        {
            button.SetActive(true);
        }
    }

}
