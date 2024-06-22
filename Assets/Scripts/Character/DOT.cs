using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOT : MonoBehaviour
{
    [SerializeField] private DOTEffect dotEffect;
    [SerializeField] private float elapsedTime;

    public void Initialize(DOTEffect effect)
    {
        dotEffect = effect;
        elapsedTime = 0f;
        InvokeRepeating("ApplyDOT", 0f, dotEffect.tickInterval);
    }

    private void ApplyDOT()
    {
        elapsedTime += dotEffect.tickInterval;
        if (elapsedTime <= dotEffect.duration)
        {
            Health health = GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(Mathf.RoundToInt(dotEffect.damagePerTick));
            }
        }
        else
        {
            CancelInvoke("ApplyDOT");
            Destroy(this);
        }
    }
}
