using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ShopItem
{
    public string DisplayName;
    public int Price;
    public Sprite Icon;

    public static int MaxPrice = 20000;

    public ShopItem(string name, int price)
    {
        DisplayName = name;
        Price = price;
        Icon = null;
        Debug.Log($"{DisplayName} created");
    }

    public void DebugPrice()
    {
        Debug.Log($"{DisplayName} costs {Price}");
    }
}
