using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2 - Ivan De Luca
public class Puerta : MonoBehaviour , IInteractable
{
    public Animator doorAnimator;
    

    public void Interact()
    {
        doorAnimator.SetTrigger("Abrirse");
        Debug.Log("puto");
    }
}
