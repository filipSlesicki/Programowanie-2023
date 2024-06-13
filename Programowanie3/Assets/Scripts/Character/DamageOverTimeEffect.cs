using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DOT effect")]
public class DamageOverTimeEffect : ScriptableObject
{
    public int Damage = 1;
    public float TickRate = 1f;
    public Sprite Icon;
    public GameObject visualEffect;
}
