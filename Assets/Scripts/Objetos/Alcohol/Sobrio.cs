using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2 - Ivan De Luca
public class Sobrio : MonoBehaviour
{
    public Animator anim;
    public float timerDuration = 15f; // Duraci�n del temporizador en segundos

    private float elapsedTime; // Tiempo transcurrido

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bool Borracho = anim.GetBool("Borracho");
        if (Borracho == true)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= timerDuration)
            {
                // El temporizador ha finalizado, realiza la acci�n deseada aqu�
                Debug.Log("ya estas sobrio");
                anim.ResetTrigger("Borracho");


                // Reinicia el temporizador (opcional)
                elapsedTime = 15f;
            }
        }
        
    }
}
