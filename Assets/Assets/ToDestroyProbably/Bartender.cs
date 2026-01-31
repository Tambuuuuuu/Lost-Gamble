using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bartender : MonoBehaviour
{
    public Animator animator;
    public string animationName;
    private bool isInsideCollider = false;

    void Update()
    {
        if (isInsideCollider && Input.GetKeyDown(KeyCode.F))
        {
            animator.Play(animationName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideCollider = false;
        }
    }
}
