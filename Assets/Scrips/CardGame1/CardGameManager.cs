using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardGameManager : MonoBehaviour
{
    public GameObject[] buttons;
    private int[] buttonValues;  // Array para guardar los valores de los botones
    private void Awake()
    {
        EventManager.SubscribeToEvent(EventsType.StartCardGame, StartGame);
    }
    public void StartGame(object[] p)
    {
        buttonValues = new int[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }

        AssignRandomNumbersToButtons();
    }
    public void TurnOffButtom(int TurOffButtom)
    {
        print("apaga boton");
        buttons[TurOffButtom].SetActive(false);
    }

    private void AssignRandomNumbersToButtons()
    {
        List<int> availableNumbers = new List<int> { 0, 1, 2, 3 };

        Shuffle(availableNumbers);
        for (int i = 0; i < buttons.Length; i++)
        {
            int randomNumber = availableNumbers[i];
            buttonValues[i] = randomNumber;
            Cards buttonValue = buttons[i].GetComponent<Cards>();
            if (buttonValue != null)
            {
                buttonValue.SetValue(randomNumber); 
            }
            print($"Botón {i} asignado al número {randomNumber}");
        }
    }

    private void Shuffle(List<int> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public int GetButtonValue(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttonValues.Length)
        {
            return buttonValues[buttonIndex]; 
        }
        return -1; 
    }
}







