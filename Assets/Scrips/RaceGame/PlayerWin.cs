using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] GameObject _PlayerWin;
    [SerializeField] GameObject _PlayerLose;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerRacer>() != null)
        {
            _PlayerWin.SetActive(true);
            _PlayerLose.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Rival"))
        {
            _PlayerWin.SetActive(false);
            _PlayerLose.SetActive(true);
        }

    }
}
