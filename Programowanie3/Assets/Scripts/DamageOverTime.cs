using UnityEngine;

[CreateAssetMenu(menuName = "DamageSO")]
public class DamageOverTime : ScriptableObject
{
    public float damage = 1;
    public float duration = 10;
    public float tickRate = 2;
}
