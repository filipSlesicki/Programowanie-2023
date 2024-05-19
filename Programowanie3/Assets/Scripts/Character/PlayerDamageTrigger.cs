using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageTrigger : MonoBehaviour
{
    public int damage = 1;
    public float rate = 0.5f;
    private float timeLeft = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0f)
            {
                Health hp = other.GetComponent<Health>();
                if(hp != null)
                {
                    hp.TakeDamage(damage);
                }

                timeLeft = rate;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timeLeft = 0f;
        }
    }
}
