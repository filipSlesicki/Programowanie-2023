using UnityEngine;

public class TemporaryModifier 
{
    public float Multiplier;
    public float Duration;
    public float RemainingDuration;

    public TemporaryModifier(float multiplier, float duration)
    {
        Multiplier = multiplier;
        Duration = duration;
        RemainingDuration = Duration;
    }
}
