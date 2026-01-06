using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//TP2 - Reinier Velez
public class UI_PPT : MonoBehaviour
{
    
    public GameObject buttonPausa;
    public GameObject buttonRenaudar;
    public GameObject buttonPiedra;
    public GameObject buttonPapel;
    public GameObject buttonTijera;
    public GameObject piedra;
    public GameObject papel;
    public GameObject tijera;
    public GameObject PanelPausa;
    public GameObject PanelInfo;
    public GameObject PanelOpciones;
    public GameObject button_Pausa;
    public GameObject button_Renaudar;




    // Start is called before the first frame update
    void Start()
    {
        buttonRenaudar.SetActive(false);
        PanelInfo.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelPausa.SetActive(false);
        piedra.SetActive(false);
        papel.SetActive(false);
        tijera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPiedra()
    {
        piedra.SetActive(true);
        papel.SetActive(false);
        tijera.SetActive(false);

    }
    public void ButtonPapel()
    {
        papel.SetActive(true);
        piedra.SetActive(false);
        tijera.SetActive(false);
    }
    public void ButtonTijera()
    {
        tijera.SetActive(true);
        papel.SetActive(false);
        piedra.SetActive(false);

    }
    public void ButtonPausa()
    {
        buttonPausa.SetActive(false);
        button_Pausa.SetActive(false);
        button_Renaudar.SetActive(true);
        buttonRenaudar.SetActive(true);
        PanelPausa.SetActive(true);
        PanelInfo.SetActive(false);
        PanelOpciones.SetActive(false);
        Time.timeScale = 0;
    }
    public void ButtonRenaudar()
    {
        buttonPausa.SetActive(true);
        button_Renaudar.SetActive(false);
        button_Pausa.SetActive(true);
        buttonRenaudar.SetActive(false);
        PanelPausa.SetActive(false);
        Time.timeScale = 1;
    }
    public void ButtonInfo()
    {
        PanelInfo.SetActive(true);
        PanelOpciones.SetActive(false);
        PanelPausa.SetActive(false);
        Time.timeScale = 0;
    }
    public void ButtonOpciones()
    {
        PanelOpciones.SetActive(true);
        PanelPausa.SetActive(false);
        PanelInfo.SetActive(false);
        Time.timeScale = 0;
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
}
