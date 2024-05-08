using UnityEngine;

[CreateAssetMenu(menuName = "DoT Effect")]
public class DamageOverTimeEffect : ScriptableObject
{
    public float damagePerTick = 3f;
    public float tickInterval = 0.5f;
    public float duration = 10f;
}