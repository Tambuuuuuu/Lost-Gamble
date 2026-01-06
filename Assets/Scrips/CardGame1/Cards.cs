using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cards : MonoBehaviour
{
    public int CardValue;

    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LoseUI;


    public void SetValue(int newValue)
    {
        CardValue = newValue;
        Debug.Log($"Valor asignado a {gameObject.name}: {CardValue}");
    }

    public int GetValue()
    {
        return CardValue;
    }

    public void CheckValue()
    {
        if (CardValue == 0)
        {
            print("you lost");
            LoseUI.SetActive(true);
        }
        else if(CardValue != 0 && CardGameEnding.instance.ClickCount < 3)
        {
            EventManager.TriggerEvent(EventsType.PlayerWon);
            WinUI.SetActive(true);
            print("you win");
        }

    }
}

