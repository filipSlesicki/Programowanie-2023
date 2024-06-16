using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoison 
{
    public bool IsPosioned();

    public void WhilePoison();

    public void SetPosion(float addPoisonTime);

}
