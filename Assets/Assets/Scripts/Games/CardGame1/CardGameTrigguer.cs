using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameTrigguer : MonoBehaviour
{
    [SerializeField] GameObject _cardGame;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            print("active card game");
            _cardGame.SetActive(true);
            EventManager.TriggerEvent(EventsType.StartCardGame);
        }
    }
}
