using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2 - Ivan De Luca
public class Borracho : MonoBehaviour
{
    Animator anim;

    

    void Start()
    {
        
        //Agregar el animador que queramos usar
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            
            anim.SetTrigger("Borracho");
            



        }

        if (Input.GetKeyUp(KeyCode.Q))
        {

            anim.ResetTrigger("Borracho");


        }
    }

    void DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    }
}
