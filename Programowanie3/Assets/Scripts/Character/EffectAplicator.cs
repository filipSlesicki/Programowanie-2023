using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAplicator : MonoBehaviour
{
    [SerializeField] private DamageOverTimeEffect dotEffect;
    [SerializeField] private float dotEffectDuration;
    [SerializeField] private SpeedChangeEffect speedChangeEffect;
    [SerializeField] private float speedEffectDuration;

    public void ApplyEffect(GameObject target)
    {
        if(dotEffect != null && target.TryGetComponent(out Health health))
        {
            health.ApplyDOTEffect(dotEffect, dotEffectDuration);
        }

        if(speedChangeEffect != null && target.TryGetComponent(out Movement movement))
        {
            movement.ApplySpeedModifier(speedChangeEffect, speedEffectDuration);
        }
    }
}
