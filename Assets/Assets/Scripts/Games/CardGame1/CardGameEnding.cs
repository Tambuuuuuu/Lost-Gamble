using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameEnding : MonoBehaviour
{
    public static CardGameEnding instance;
    public float ClickCount = 0f;

    [SerializeField] private GameObject _FinalUI;
    [SerializeField] private GameObject _WinUI;
    [SerializeField] private GameObject _LoseUI;
    private void Awake()
    {
        instance = this;
        EventManager.SubscribeToEvent(EventsType.StartCardGame, ResetClickCount);
        EventManager.SubscribeToEvent(EventsType.StartCardGame, ResetScreens);
    }
    public void ResetClickCount(object[] p)
    {
        ClickCount = 0f;
    }

    public void ResetScreens(object[] p)
    {
        _FinalUI.SetActive(false);
        _WinUI.SetActive(false);
        _LoseUI.SetActive(false);
    }

    public void AddClick()
    {
        ClickCount += 1;
        if(ClickCount >= 3)
        {
            _FinalUI.SetActive(true);
        }
    }


}
