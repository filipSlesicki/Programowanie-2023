using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] UnityEvent<int, int> OnHealthChanged;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth,maxHealth);
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


}
