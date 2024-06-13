using UnityEngine;

public class EffectTimer 
{
    public float RemainingDuration;
    public float LastTickTime;

    public EffectTimer(float duration)
    {
        RemainingDuration = duration;
        LastTickTime = Time.time;
    }
}
