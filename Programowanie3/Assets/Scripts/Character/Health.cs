using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] UnityEvent<int, int> OnHealthChanged;
    [HideInInspector] public int currentHealth;

    private Dictionary<DamageOverTimeEffect, EffectTimer> DOTEffects = new Dictionary<DamageOverTimeEffect, EffectTimer>();
    private List<DamageOverTimeEffect> toRemove = new List<DamageOverTimeEffect>();

    private void Awake()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    public void TakeDamagePercentage(float percentage)
    {
        float damge = currentHealth * percentage / 100;
        TakeDamage(Mathf.RoundToInt(damge));
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void ApplyDOTEffect(DamageOverTimeEffect effect, float duration)
    {
        DOTEffects[effect] = new EffectTimer(duration);
    }

    private void Update()
    {
        UpdateDOTEffects();
    }

    private void UpdateDOTEffects()
    {
        foreach ((DamageOverTimeEffect effect, EffectTimer effectTimer) in DOTEffects)
        {
            effectTimer.RemainingDuration -= Time.deltaTime;
            if (effectTimer.LastTickTime + effect.TickRate <= Time.time)
            {
                TakeDamage(effect.Damage);
                effectTimer.LastTickTime = Time.time;
            }
            if (effectTimer.RemainingDuration <= 0)
            {
                toRemove.Add(effect);
            }
        }

        foreach (var modifier in toRemove)
        {
            DOTEffects.Remove(modifier);
        }
        toRemove.Clear();
    }

}
