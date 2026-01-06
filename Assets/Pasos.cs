using UnityEngine;
//TP2 - Federico Ziella
public class FootstepSound : MonoBehaviour
{
    public AudioClip footstepSound; // Clip de sonido de caminata
    private AudioSource audioSource;
    private bool isWalking = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Verificar si se est� presionando alguna de las teclas de movimiento
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        // Si se est� moviendo y no estaba caminando antes, iniciar la reproducci�n del sonido
        if (isMoving && !isWalking)
        {
            isWalking = true;
            PlayFootstepSound();
        }
        // Si no se est� moviendo y estaba caminando antes, detener la reproducci�n del sonido
        else if (!isMoving && isWalking)
        {
            isWalking = false;
            StopFootstepSound();
        }
    }

    void PlayFootstepSound()
    {
        if (footstepSound != null && !audioSource.isPlaying)
        {
            audioSource.clip = footstepSound;
            audioSource.Play();
        }
    }

    void StopFootstepSound()
    {
        audioSource.Stop();
    }
}
