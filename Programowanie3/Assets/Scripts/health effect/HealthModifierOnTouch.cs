using UnityEngine;

public class HealthModifierOnTouch : MonoBehaviour
{
    public float duration;
    public HealthChangeEffect effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.ApplyHealthModifier(effect, duration);
        }
    }
}
