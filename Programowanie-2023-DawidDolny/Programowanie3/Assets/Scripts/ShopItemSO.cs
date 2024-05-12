using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName = "Items/ShopItem")]
public class ShopItemSO : ScriptableObject
{
    public string DisplayName;
    public int Price;
    public Sprite Icon;

    public void DebugPrice()
    {
        Debug.Log($"{DisplayName} costs {Price}");
    }
}
