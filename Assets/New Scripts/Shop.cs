using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Currency playerCurrency;
    public ShopItem item;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            TryBuy();
        }
    }
    public void TryBuy()
    {
        if (playerCurrency == null)
        {
            Debug.LogError("No hay referencia al PlayerCurrency");
            return;
        }

        if (playerCurrency.SpendMoney(item.price))
        {
            Debug.Log("Compraste: " + item.itemName);
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar " + item.itemName);
        }
    }

}
