using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panelAcciones;        // Envido / Truco
    public GameObject panelEnvidoOpciones;  // Envido / Real / Falta
    public GameObject botonCancelar;

    void Start()
    {
        panelEnvidoOpciones.SetActive(false);
        botonCancelar.SetActive(false);
    }

    // ===== BOTÓN ENVIDO =====
    public void OnClickAbrirEnvido()
    {
        panelAcciones.SetActive(false);
        panelEnvidoOpciones.SetActive(true);
        botonCancelar.SetActive(true);

        Debug.Log("📣 UI → Opciones de ENVIDO abiertas");
    }

    // ===== BOTÓN CANCELAR =====
    public void OnClickCancelarEnvido()
    {
        panelEnvidoOpciones.SetActive(false);
        botonCancelar.SetActive(false);
        panelAcciones.SetActive(true);

        Debug.Log("↩️ UI → Envido cancelado");
    }

    // ===== BOTONES DE OPCIONES =====
    public void OnClickEnvido()
    {
        Debug.Log("🃏 ENVIDO seleccionado");
        CerrarMenuEnvido();
    }

    public void OnClickRealEnvido()
    {
        Debug.Log("🃏 REAL ENVIDO seleccionado");
        CerrarMenuEnvido();
    }

    public void OnClickFaltaEnvido()
    {
        Debug.Log("🃏 FALTA ENVIDO seleccionado");
        CerrarMenuEnvido();
    }

    void CerrarMenuEnvido()
    {
        panelEnvidoOpciones.SetActive(false);
        botonCancelar.SetActive(false);
        panelAcciones.SetActive(true);
    }

}
