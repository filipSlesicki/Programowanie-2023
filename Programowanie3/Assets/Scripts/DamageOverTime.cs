using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    [SerializeField] private DamageOverTimeEffect dotEffect;
    [SerializeField] private float elapsedTime;

    public void Initialize(DamageOverTimeEffect effect)
    {
        dotEffect = effect;
        elapsedTime = 0f;
        InvokeRepeating("ApplyDoT", 0f, dotEffect.tickInterval);
    }

    private void ApplyDoT()
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
            CancelInvoke("ApplyDoT");
            Destroy(this);
        }
    }
}
