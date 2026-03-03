using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyUI : MonoBehaviour
{
    public Currency playerCurrency;
    public TextMeshProUGUI moneyText;

    void Start()
    {
        UpdateMoney(playerCurrency.CurrentMoney);

        playerCurrency.OnMoneyChanged += UpdateMoney;
    }

    void UpdateMoney(int newAmount)
    {
        moneyText.text = "$ " + newAmount.ToString();
    }

    private void OnDestroy()
    {
        playerCurrency.OnMoneyChanged -= UpdateMoney;
    }

}
