using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float damage;
    private float dmgCzas;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            if (dmgCzas < 1)
            {
                dmgCzas += Time.deltaTime * damage;
            }
            else
            {
                dmgCzas = 0;
                other.GetComponent<Health>().TakeDamage(1);
            }
        }
    }
}
