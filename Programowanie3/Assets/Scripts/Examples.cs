using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examples : MonoBehaviour
{  
    // Komentarz
    // modyfikator dostêpu private/public
    public int count = 0;
    //typ nazwa = wartoœæ pocz¹tkowa
    //float testFloat = 1f;  
    void DebugSum(int a, int b)
    {
        Debug.Log(a + b);
    }

    bool IsPositive(float value)
    {
        return value >= 0;
        if (value > 0)
        {
            return true;
        }
        else if (value < 0)
        {
            return false;
        }
        else
        {
            Debug.Log("Value is 0");
            return true;
        }
    }

    bool IsEven(int value)
    {
        // Modulo operator (%) to reszta z dzielenia
        //Je¿eli wartoœæ dzieli siê przez 2 bez reszty, to jest dodatnia
        return value % 2 == 0;
        int halfValue = value / 2;
        return value == halfValue * 2;
    }

    bool IsOdd(int value)
    {
        return !IsEven(value);
    }
}
