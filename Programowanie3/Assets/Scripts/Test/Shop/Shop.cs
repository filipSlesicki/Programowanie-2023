using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItemSO> items;
    [SerializeField] private ShopKeeper shopKeeper;
    void Start()
    {
        ShopItem.MaxPrice = 1;
        ShopItem itemClass1 = new ShopItem("Klasa 1", 100);
        ShopItem itemClass2 = itemClass1; // itemClass2 odnosi siê do itemClass1
        itemClass2.Price = 200; // Jak zmieniamy wartoœæ w itemClass2, to zmienia siê te¿ w itemClass1

        Discount(itemClass1, 50);
        itemClass1.DebugPrice();
        
        ShopItemStruct itemStruct1 = new ShopItemStruct("Struct 1", 100);
        ShopItemStruct itemStruct2 = itemStruct1; // itemStruct2 jest kopi¹ itemStruct1
        itemStruct2.Price = 200; // Zmiana wartoœci itemStruct2 nie ma wp³ywu na itemStruct1
        itemStruct1.DebugPrice();
        Discount(ref itemStruct1, 50);
        itemStruct1.DebugPrice();
        //ShopKeeper shopKeeper = new ShopKeeper("Bob", "Look at my items");
        //ShopItem potion = new ShopItem("Potion", 100);
        //ShopItem sword = new ShopItem("Sword", 500);

        //items.Add(potion);
        //items.Add(sword);

        //Debug.Log(shopKeeper.DialogueLine);
        //foreach (ShopItem item in items)
        //{
        //    Debug.Log(item.DisplayName);
        //}    
    }


    void Discount(ShopItem item, int discount)
    {
        item.Price -=  discount;
    }

    
    void Discount(ref ShopItemStruct item, int discount)
    {
        //ref sprawia, ¿e traktujemy wartoœæ tak jak referencje
        item.Price -= discount;
    }
}
