using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Health effect")]
public class HealthChangeEffect : ScriptableObject
{
    public float Multiplier;
    public Sprite Icon;
    public GameObject visualEffect;
}
