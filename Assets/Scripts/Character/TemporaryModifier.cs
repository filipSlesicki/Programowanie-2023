using UnityEngine;

public class TemporaryModifier 
{
    public float Multiplier;
    public float RemainingDuration;

    public TemporaryModifier(float multiplier, float duration)
    {
        Multiplier = multiplier;
        RemainingDuration = duration;
    }

    /// <summary>
    /// Decrease <see cref="RemainingDuration"/> by delta time
    /// </summary>
    /// <returns>True if duration is <=0 and modifier should be removed</returns>
    public bool Tick()
    {
        RemainingDuration -= Time.deltaTime;
        return RemainingDuration <= 0;
    }
}
