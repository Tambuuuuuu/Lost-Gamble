using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    private GameObject skillTree;
    private bool abierto = false;

    void Start()
    {
        GameObject[] objetos = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in objetos)
        {
            if (obj.name == "Skilltree")
            {
                skillTree = obj;
                break;
            }
        }

        if (skillTree == null)
        {
            Debug.LogWarning("No se encontró el objeto 'Skilltree'");
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && skillTree != null)
        {
            abierto = !abierto;

            skillTree.SetActive(abierto);

            if (abierto)
            {
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

}
