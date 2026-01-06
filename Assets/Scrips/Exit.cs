using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] GameObject _CardGameInterface;
    [SerializeField] GameObject _WinUI;
    [SerializeField] GameObject _LoseUI;
    [SerializeField] GameObject _FinalUI;


    public void OffGame()
    {
        _CardGameInterface.SetActive(false);
        _WinUI.SetActive(false);
        _LoseUI.SetActive(false);
        _FinalUI.SetActive(false);
    }
}
