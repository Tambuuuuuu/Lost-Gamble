using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//TP2 - Ivan De Luca
public class Menu : MonoBehaviour
{

    public void EmpezarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Se cerro el juego");
    }
    
}
