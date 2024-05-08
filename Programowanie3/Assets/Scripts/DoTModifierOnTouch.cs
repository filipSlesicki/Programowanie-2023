using UnityEngine;

public class DoTModifierOnTouch : MonoBehaviour
{
    public DamageOverTimeEffect dotEffect;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.TryGetComponent(out Health health))
        {
            Debug.Log("WykrytoHealth");
            DamageOverTime dot = other.gameObject.AddComponent<DamageOverTime>();
            dot.Initialize(dotEffect);
        }
    }
}