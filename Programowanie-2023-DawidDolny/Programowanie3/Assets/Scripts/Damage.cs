using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public DOT dot;
    private float elapseTimer;

    public void startDamage(DOT effect)
    {
        dot = effect;
        elapseTimer = 0f;
        InvokeRepeating("applyEffect", 0f, dot.tickRate);
    }

    private void applyEffect()
    {
        elapseTimer += dot.tickRate;
       
        if (elapseTimer <= dot.duration)
        {
            Health health = GetComponent<Health>();
           
            if (health != null) 
            {
                health.TakeDamage(Mathf.RoundToInt(dot.damage));
            }
          
            else
            {
                CancelInvoke("applyEffect");
                Destroy(this);
            }
        }
    }
}
