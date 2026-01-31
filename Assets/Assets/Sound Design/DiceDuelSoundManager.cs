using UnityEngine;
using System.Collections;
//TP2 - Federico Ziella
public class DiceDuelSoundManager : MonoBehaviour
{
    public AudioClip firstEffectSound; // Primer clip de sonido
    public AudioClip secondEffectSound; // Segundo clip de sonido
    public AudioClip victoryMusic; // M�sica de victoria
    public AudioClip defeatMusic; // M�sica de derrota
    private AudioSource audioSource; // Componente AudioSource
    private int playCount = 0;// Resultados de los dados del oponente

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtener el componente AudioSource
    }
    public void PlayFirstSound()
    {
        audioSource.PlayOneShot(firstEffectSound); // Reproducir el primer sonido
    }
    public void PlaySecondSound()
    {
        audioSource.PlayOneShot(secondEffectSound); // Reproducir el segundo sonido
    }
    public void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}


