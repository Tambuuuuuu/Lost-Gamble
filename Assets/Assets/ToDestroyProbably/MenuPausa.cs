using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeImage : MonoBehaviour
{
    public GameObject imageCanvasGroup;
    public static bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleImage();
        }
    }

    public void ToggleImage()
    {
        if (imageCanvasGroup.activeInHierarchy == false)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    void Pause()
    {
        imageCanvasGroup.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        imageCanvasGroup.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}