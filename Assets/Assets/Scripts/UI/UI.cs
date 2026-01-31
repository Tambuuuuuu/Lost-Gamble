using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//TP2 - Reinier Velez
public class UI : MonoBehaviour
{
    public GameObject puntoP;
    public GameObject puntoP1;
    public GameObject puntoP2;
    public GameObject puntoE;
    public GameObject puntoE1;
    public GameObject puntoE2;
    public GameObject buttonPausa;
    public GameObject buttonRenaudar;
    //public GameObject buttonInfo;
    //public GameObject buttonMenu;
    //public GameObject buttonOpciones;
    public GameObject PanelPausa;
    public GameObject PanelInfo;
    public GameObject PanelOpciones;
    public GameObject button_Pausa;
    public GameObject button_Renaudar;
    public Combate ui;
    public PPT ppt;
    public Ruleta ruleta;




    // Start is called before the first frame update
    void Start()
    {
        puntoE.SetActive(false);
        puntoE1.SetActive(false);
        puntoE2.SetActive(false);
        puntoP.SetActive(false);
        puntoP1.SetActive(false);
        puntoP2.SetActive(false);
        buttonRenaudar.SetActive(false);
        PanelInfo.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelPausa.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        ui = FindObjectOfType<Combate>();
        ppt = FindObjectOfType<PPT>();
        ruleta = FindObjectOfType<Ruleta>();
        if (ui != null)
        {
            if (ui.puntosJugador == 1)
            {
                puntoP.SetActive(true);
            }
            else if (ui.puntosJugador == 2)
            {
                puntoP.SetActive(true);
                puntoP1.SetActive(true);
            }
            else if (ui.puntosJugador == 3)
            {
                puntoP.SetActive(true);
                puntoP1.SetActive(true);
                puntoP2.SetActive(true);
            }

            if (ui.puntosEnemigo == 1)
            {
                puntoE.SetActive(true);
            }
            else if (ui.puntosEnemigo == 2)
            {
                puntoE.SetActive(true);
                puntoE1.SetActive(true);
            }
            else if (ui.puntosEnemigo == 3)
            {
                puntoE.SetActive(true);
                puntoE1.SetActive(true);
                puntoE2.SetActive(true);
            }
        
        }
        else if (ppt != null)
        {
            if (ppt.puntosJugador == 1)
            {
                puntoP.SetActive(true);
            }
            else if (ppt.puntosJugador == 2)
            {
                puntoP.SetActive(true);
                puntoP1.SetActive(true);
            }
            else if (ppt.puntosJugador == 3)
            {
                puntoP.SetActive(true);
                puntoP1.SetActive(true);
                puntoP2.SetActive(true);
            }

            if (ppt.puntosEnemigo == 1)
            {
                puntoE.SetActive(true);
            }
            else if (ppt.puntosEnemigo == 2)
            {
                puntoE.SetActive(true);
                puntoE1.SetActive(true);
            }
            else if (ppt.puntosEnemigo == 3)
            {
                puntoE.SetActive(true);
                puntoE1.SetActive(true);
                puntoE2.SetActive(true);
            }
        }
        else if (ruleta != null)
        {
            if (ruleta.puntosJugador == 1)
            {
                puntoP.SetActive(true);
            }
            else if (ruleta.puntosJugador == 2)
            {
                puntoP.SetActive(true);
                puntoP1.SetActive(true);
            }
            else if (ruleta.puntosJugador == 3)
            {
                puntoP.SetActive(true);
                puntoP1.SetActive(true);
                puntoP2.SetActive(true);
            }

            if (ruleta.puntosEnemigo == 1)
            {
                puntoE.SetActive(true);
            }
            else if (ruleta.puntosEnemigo == 2)
            {
                puntoE.SetActive(true);
                puntoE1.SetActive(true);
            }
            else if (ruleta.puntosEnemigo == 3)
            {
                puntoE.SetActive(true);
                puntoE1.SetActive(true);
                puntoE2.SetActive(true);
            }

        }
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
        PanelInfo.SetActive(false);
        PanelOpciones.SetActive(false);
        Time.timeScale = 1;
    }
    public void ButtonInfo()
    {
        PanelInfo.SetActive(true);
        PanelOpciones.SetActive(false);
        PanelPausa.SetActive(false);
        buttonPausa.SetActive(false);
        button_Pausa.SetActive(false);
        button_Renaudar.SetActive(true);
        buttonRenaudar.SetActive(true);
        Time.timeScale = 0;
    }
    public void ButtonOpciones()
    {
        PanelOpciones.SetActive(true);
        PanelPausa.SetActive(false);
        PanelInfo.SetActive(false);
        buttonPausa.SetActive(false);
        button_Pausa.SetActive(false);
        button_Renaudar.SetActive(true);
        buttonRenaudar.SetActive(true);
        Time.timeScale = 0;
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
