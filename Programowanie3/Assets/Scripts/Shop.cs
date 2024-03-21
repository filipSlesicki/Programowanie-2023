using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItem> items;
    [SerializeField] private ShopKeeper shopKeeper;
    void Start()
    {
        //ShopKeeper shopKeeper = new ShopKeeper("Bob", "Look at my items");
        //ShopItem potion = new ShopItem("Potion", 100);
        //ShopItem sword = new ShopItem("Sword", 500);
       
        //items.Add(potion);
        //items.Add(sword);

        Debug.Log(shopKeeper.DialogueLine);
        foreach (ShopItem item in items)
        {
            Debug.Log(item.DisplayName);
        }    
    }

}
