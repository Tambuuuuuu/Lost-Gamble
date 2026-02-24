using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public Dialogo dialogo;
    public KeyCode teclaInteractuar = KeyCode.E;

    private bool jugadorCerca;

    void Update()
    {
        if (dialogo.gameObject.activeSelf) return;

        if (jugadorCerca && Input.GetKeyDown(teclaInteractuar))
        {
            dialogo.gameObject.SetActive(true);
            dialogo.StarDialogo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            jugadorCerca = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            jugadorCerca = false;
    }
}