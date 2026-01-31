using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2 - Ivan De Luca
public class Levantarse : MonoBehaviour
{
    Animator anim;

    AnimacionCorrer Correr;

    void Start()
    {

        //Agregar el animador que queramos usar
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {


            anim.SetTrigger("Enelpiso");




        }

        if (Input.GetKeyUp(KeyCode.T))
        {

            anim.ResetTrigger("Enelpiso");


        }
    }
}
