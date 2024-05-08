using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Speed effect")]
public class SpeedChangeEffect : ScriptableObject
{
    public float Multiplier;
    public Sprite Icon;
    public GameObject visualEffect;
}
