using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opera : MonoBehaviour
{
    public AudioSource targetAudioSource;
    private bool isInsideCollider = false;

    void Update()
    {
        if (isInsideCollider && Input.GetKeyDown(KeyCode.F))
        {
            targetAudioSource.Stop();
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
            if (!targetAudioSource.isPlaying)
            {
                targetAudioSource.Play();
            }
        }
    }
}
