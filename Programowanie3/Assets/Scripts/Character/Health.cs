using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IPoison
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] UnityEvent<int, int> OnHealthChanged;
    private int currentHealth;

    [Header("Poison effect")]
    private bool isPoisoned;
    float poisonTime;
    private float doDmgFromPoison;



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


    //poison
    public bool IsPosioned()
    {
        return isPoisoned;
    }


    public void WhilePoison()
    {
        doDmgFromPoison += Time.deltaTime;
        if (doDmgFromPoison > 1)
        {
            TakeDamage(1);
            doDmgFromPoison = 0;
        }
    }

    public void SetPosion(float addPoisonTime)
    {
        poisonTime += addPoisonTime;
        if (IsPosioned())
        {
            return;
        }
        StartCoroutine(DoPoison());
    }

    private IEnumerator DoPoison()
    {
        isPoisoned = true;
        while (poisonTime > 0)
        {
            poisonTime -= Time.deltaTime;
            WhilePoison();
            yield return new WaitForEndOfFrame();
        }
        doDmgFromPoison = 0;

        isPoisoned = false;
    }
}
