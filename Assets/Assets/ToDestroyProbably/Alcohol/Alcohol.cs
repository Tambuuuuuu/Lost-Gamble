using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2 - Ivan De Luca
public class Alcohol : MonoBehaviour, IInteractable
{
    public Animator anim;
   public void Interact()
   {
        Debug.Log(Random.Range(0, 100));
        anim.SetTrigger("Borracho");
   }
}
