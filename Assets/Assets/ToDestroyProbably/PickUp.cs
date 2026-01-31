using UnityEngine;
//TP2 - Federico Ziella
public class ObjectPickup : MonoBehaviour
{
    public AudioClip pickupSound; // Clip de sonido cuando se toma el objeto
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayPickupSound();
            Debug.Log("Recogiste un objeto");
        }
    }

    void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }
}
