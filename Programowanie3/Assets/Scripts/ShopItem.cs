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

    public ShopItem(string name, int price)
    {
        DisplayName = name;
        Price = price;
        Debug.Log($"{DisplayName} created");
    }
}
