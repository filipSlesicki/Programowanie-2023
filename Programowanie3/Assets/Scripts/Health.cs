using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 7;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] UnityEvent<int, int> OnHealthChanged;

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


}
