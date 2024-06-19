using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int health = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if(playerHealth != null)
            {
                playerHealth.Heal(health);
            }
        }
    }
}
