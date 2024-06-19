using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopKeeper 
{
    public string Name;
    public string DialogueLine;

    public ShopKeeper(string name, string dialogueLine)
    {
        Name = name;
        DialogueLine = dialogueLine;
    }
}
