using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTModifier : MonoBehaviour
{
    public float damage;
    private float damagetime;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Health>())
        {
         if (damagetime < 1)
            {
                damagetime += Time.deltaTime * damage;
            }
            else
            {
                damagetime = 0;
                other.GetComponent<Health>().TakeDamage(1);
            }
        }
    } 
}