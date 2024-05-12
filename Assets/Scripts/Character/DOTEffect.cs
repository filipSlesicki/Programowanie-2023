using UnityEngine;

[CreateAssetMenu(menuName = "DOTEffect")]
public class DOTEffect : ScriptableObject
{
    public float damagePerTick = 4f;
    public float tickInterval = 0.5f;
    public float duration = 11f;
}