using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private bool isPaused = false;

    void Start()
    {
        // Buscar el objeto en la jerarquía por nombre
        pauseMenu = GameObject.Find("PauseMenu");

        if (pauseMenu == null)
        {
            Debug.LogError("No se encontró el objeto PauseMenu en la jerarquía");
            return;
        }

        // Asegurarse de que empiece apagado
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Ejemplo: presionar ESC para pausar / reanudar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        pauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}

