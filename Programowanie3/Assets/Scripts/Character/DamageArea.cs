using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public float damage;
    private float timer;
    public float damageTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            if (timer < damageTime)
            {
                timer += Time.deltaTime;
            }

            else
            {
                timer = 0;
                other.GetComponent<Health>().TakeDamage(1);
            }
        }
    }
}
