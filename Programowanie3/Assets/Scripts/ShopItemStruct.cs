using System;
using UnityEngine;

[Serializable]
public struct ShopItemStruct
{
    public string DisplayName;
    public int Price;
    public Sprite Icon;

    public ShopItemStruct(string name, int price)
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
