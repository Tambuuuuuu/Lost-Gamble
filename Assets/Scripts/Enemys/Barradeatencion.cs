using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Barradeatencion : MonoBehaviour
{
    [SerializeField]protected  int puntosDeteccion;
    [SerializeField]protected  bool deteccionTriggered;
    [SerializeField]protected  bool nocheating;
    [SerializeField]protected GameObject atencion1;
    [SerializeField]protected  GameObject atencion2;
    [SerializeField]protected  GameObject atencion3;
    public DiceDuelSoundManager sound;
    public bool trucoMoneda;
    public bool trucoPintura;
    public bool trucoWhisky;
    public bool trucoKamikaze;
    public bool trucoContrato;
    public bool trucoX2;
    protected virtual void Start()
    {
        if (atencion1 == null)
        {
            atencion1 = GameObject.FindGameObjectWithTag("Atencion1");
            atencion1.SetActive(false);
        }
        if (atencion2 == null)
        {
            atencion2 = GameObject.FindGameObjectWithTag("Atencion2");
            atencion2.SetActive(false);
        }
        if (atencion3 == null)
        {
            atencion3 = GameObject.FindGameObjectWithTag("Atencion3");
            atencion3.SetActive(false);
        }
        sound = FindObjectOfType<DiceDuelSoundManager>();
    }
    protected virtual void Update()
    {
        if (puntosDeteccion < 0)
        {
            puntosDeteccion = 0;
        }
        Derrota();
    }
    public void deteccion<T>(T juego)
    {
        if (juego != null && deteccionTriggered == false)
        {
            print("Entro");
            if (trucoMoneda || trucoPintura || trucoWhisky || trucoContrato || trucoX2)
            {
                puntosDeteccion++;
                deteccionTriggered = true;
                Debug.Log("Trampa? nahhhhh");

                if(atencion1.activeInHierarchy == false && atencion2.activeInHierarchy == false && atencion3.activeInHierarchy == false && puntosDeteccion == 1)
                {
                    atencion1.SetActive(true);
                }

                if(atencion1.activeInHierarchy == true && atencion2.activeInHierarchy == false && atencion3.activeInHierarchy == false && puntosDeteccion == 2)
                {
                    atencion2.SetActive(true);
                }

                if (atencion1.activeInHierarchy == true && atencion2.activeInHierarchy == true && atencion3.activeInHierarchy == true && puntosDeteccion == 3)
                {
                    atencion3.SetActive(true);
                }
            }
        }
    }
    public void Nodeteccion<T>(T juego)
    {
        if (juego != null && nocheating == false)
        {
            print("Entro2");
            if (!trucoMoneda || !trucoPintura || !trucoWhisky || !trucoX2 || !trucoContrato)
            {
                puntosDeteccion--;
                nocheating = true;
                Debug.Log("No cheating detected. Subtracting detection points...");

                if (atencion1.activeInHierarchy == true && atencion2.activeInHierarchy == true && atencion3.activeInHierarchy == false && puntosDeteccion == 1)
                {
                    atencion2.SetActive(false);
                }

                if (atencion1.activeInHierarchy == true && atencion2.activeInHierarchy == false && atencion3.activeInHierarchy == false && puntosDeteccion == 0)
                {
                    atencion1.SetActive(false);
                }
            }
        }
    }
    protected virtual void Derrota()
    {
        if (puntosDeteccion >= 3)
        {
            sound.PlayMusic(sound.defeatMusic);
            Inventario inv = FindObjectOfType<Inventario>();
            inv.inGame = false;
            SceneManager.LoadScene(1);
        }
    }


}
