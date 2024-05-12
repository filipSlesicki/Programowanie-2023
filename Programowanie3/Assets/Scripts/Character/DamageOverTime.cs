using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public float dmg;
    private float dmgTimer;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            if (dmgTimer < 1)
            {
                dmgTimer += Time.deltaTime * dmg;
            }
            else
            {
                dmgTimer = 0;
                other.GetComponent<Health>().TakeDamage(1);
            }

        }
    }
    
}