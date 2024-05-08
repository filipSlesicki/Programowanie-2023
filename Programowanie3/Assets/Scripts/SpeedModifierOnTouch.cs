using UnityEngine;

public class SpeedModifierOnTouch : MonoBehaviour
{
    [SerializeField] private SpeedChangeEffect effect;
    [SerializeField] private float duration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement movement))
        {
            movement.ApplySpeedModifier(effect, duration);
        }
    }
}
