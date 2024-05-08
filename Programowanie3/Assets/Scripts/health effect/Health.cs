using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] UnityEvent<int, int> OnHealthChanged;
    private float currentHealth;
    private Dictionary<HealthChangeEffect, TemporaryModifier> temporaryHealthModifiers = new Dictionary<HealthChangeEffect, TemporaryModifier>();

    private void Start()
    {
        OnHealthChanged?.Invoke(health,maxHealth);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        OnHealthChanged?.Invoke(health, maxHealth);
        if (health <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    public void TakeDamagePercentage(float percentage)
    {
        float damge = health * percentage / 100;
        TakeDamage(Mathf.RoundToInt(damge));
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        OnHealthChanged?.Invoke(health, maxHealth);
    }

    public void ApplyHealthModifier(HealthChangeEffect effect, float duration)
    {
        if (temporaryHealthModifiers.ContainsKey(effect))
        {
            temporaryHealthModifiers[effect].RemainingDuration += duration;
        }
        else
        {
            temporaryHealthModifiers.Add(effect, new TemporaryModifier(effect.Multiplier, duration));
            currentHealth *= effect.Multiplier;
        }
    }

    private void Update()
    {
        List<HealthChangeEffect> toRemove = new List<HealthChangeEffect>();
        foreach (var modifier in temporaryHealthModifiers)
        {
            modifier.Value.RemainingDuration -= Time.deltaTime;
            if (modifier.Value.RemainingDuration <= 0)
            {
                currentHealth /= modifier.Value.Multiplier;
                toRemove.Add(modifier.Key);
            }
        }

        foreach (var modifier in toRemove)
        {
            temporaryHealthModifiers.Remove(modifier);
        }
    }
}
