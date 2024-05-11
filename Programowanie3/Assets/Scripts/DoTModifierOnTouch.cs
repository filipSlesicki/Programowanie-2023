using UnityEngine;

public class DoTModifierOnTouch : MonoBehaviour
{
    public DamageOverTimeEffect dotEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            DamageOverTime dot = other.gameObject.AddComponent<DamageOverTime>();
            dot.Initialize(dotEffect);
        }
    }
}