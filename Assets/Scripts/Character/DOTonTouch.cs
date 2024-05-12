using UnityEngine;

public class DOTonTouch : MonoBehaviour
{
    public DOTEffect dotEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            DOT dot = other.gameObject.AddComponent<DOT>();
            dot.Initialize(dotEffect);
        }
    }
}
