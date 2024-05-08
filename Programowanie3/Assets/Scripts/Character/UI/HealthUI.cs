using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image healthbar;

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        if (healthText != null)
        {
            healthText.text = $"Health {currentHealth}";
        }
        if (healthbar != null)
        {
            healthbar.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
