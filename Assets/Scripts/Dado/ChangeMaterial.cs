using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeMaterial : MonoBehaviour
{
    public Material newMaterial;
    public Material oldMaterial;// El nuevo material que quieres asignar
    DadoPlayer dadoPlayer;
    public void cambiar()
    {
        // Asegúrate de que el GameObject tiene un Renderer
        Renderer renderer = GetComponent<Renderer>();
        
        if (renderer != null)
        {
            // Cambia el material del objeto al nuevo material
            renderer.material = newMaterial;
        }
    }
    public void volver()
    {
        // Asegúrate de que el GameObject tiene un Renderer
        Renderer renderer = GetComponent<Renderer>();
       
        
            if (renderer != null)
            {
                // Cambia el material del objeto al nuevo material
                renderer.material = oldMaterial;
            }
        
    }
}

