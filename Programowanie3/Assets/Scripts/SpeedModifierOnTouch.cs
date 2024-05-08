using UnityEngine;

public class SpeedModifierOnTouch : MonoBehaviour
{
    public float duration;
    public SpeedChangeEffect effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement movement))
        {
            movement.ApplySpeedModifier(effect, duration);
        }
    }
}
