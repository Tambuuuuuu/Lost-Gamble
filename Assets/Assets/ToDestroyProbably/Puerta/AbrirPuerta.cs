using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2 - Ivan De Luca
public class AbrirPuerta : MonoBehaviour
{
    public float interactionDistance = 2f;
    private IInteractable currentInteractable;
    public Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
            anim.SetTrigger("AgarrarObjeto");
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            anim.ResetTrigger("AgarrarObjeto");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindNearbyInteractable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentInteractable = null;
        }
    }

    private void FindNearbyInteractable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionDistance);

        foreach (Collider collider in colliders)
        {
            IInteractable interactable = collider.gameObject.GetComponent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;
                break;
            }
        }
    }
}
