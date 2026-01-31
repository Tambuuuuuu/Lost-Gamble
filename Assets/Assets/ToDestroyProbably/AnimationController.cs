using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationController : MonoBehaviour
{
    Animator anim;

    AnimacionCorrer Correr;
    
    void Start()
    {
        
    anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            

            anim.SetTrigger("AgarrarObjeto");

            
           
            
        }

        if(Input.GetKeyUp(KeyCode.F))
        {
            
            anim.ResetTrigger("AgarrarObjeto");

            
        }
    }

    
}
