using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public DamageOverTime damageovertime;
    private float elapseTimer;

    public void startDamage(DamageOverTime effect)
    {
        damageovertime = effect;
        elapseTimer = 0f;
        InvokeRepeating("applyEffect", 0f, damageovertime.tickRate);
    }

    private void applyEffect()
    {
        elapseTimer += damageovertime.tickRate;
       
        if (elapseTimer <= damageovertime.duration)
        {
            Health health = GetComponent<Health>();
           
            if (health != null) 
            {
                health.TakeDamage(Mathf.RoundToInt(damageovertime.damage));
            }
          
            else
            {
                CancelInvoke("applyEffect");
                Destroy(this);
            }
        }
    }
}
