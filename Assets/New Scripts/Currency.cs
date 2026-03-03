using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Currency : MonoBehaviour
{
    [Header("Currency")]
    [SerializeField] private int currentMoney = 0;

    public int CurrentMoney => currentMoney;

    public event Action<int> OnMoneyChanged;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            FindObjectOfType<Currency>().AddMoney(10);
        }
    }
    public void AddMoney(int amount)
    {
        if (amount <= 0) return;

        currentMoney += amount;
        OnMoneyChanged?.Invoke(currentMoney);
    }

    public bool SpendMoney(int amount)
    {
        if (amount <= 0) return false;

        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            OnMoneyChanged?.Invoke(currentMoney);
            return true;
        }

        return false;
    }
}
