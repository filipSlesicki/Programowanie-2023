using UnityEngine;

[CreateAssetMenu(menuName = "DamageSO")]
public class DOT : ScriptableObject
{
    public float damage = 2;
    public float duration = 15;
    public float tickRate = 3;
}
