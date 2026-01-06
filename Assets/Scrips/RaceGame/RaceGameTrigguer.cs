using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceGameTrigguer : MonoBehaviour
{
    [SerializeField] GameObject _raceGameInterface;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            print("on race game");
            _raceGameInterface.SetActive(true);
        }
    }
}
