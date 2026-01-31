using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2 - Reinier Velez
public class GameEvent : MonoBehaviour
{
    public static GameEvent Instance;
    public static Action EnterDado;
    public static Action EnterPPT;
    public static Action EnterLose;
    public static Action EnterVictory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void dado()
    {
        EnterDado?.Invoke();
    }
    public void ppt()
    {
        EnterPPT?.Invoke();
    }
    public void lose()
    {
        EnterLose?.Invoke();
    }
    public void victory()
    {
        EnterVictory?.Invoke();
    }
}
