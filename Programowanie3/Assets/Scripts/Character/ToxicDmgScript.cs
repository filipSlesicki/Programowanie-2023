using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicDmgScript : MonoBehaviour
{
    public float toxicdmg;
    private float toxicDmgTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            if (toxicDmgTime < 1)
            {
                toxicDmgTime += Time.deltaTime * toxicdmg;
            }
            else
            {
                toxicDmgTime = 0;
                other.GetComponent<Health>().TakeDamage(1);
            }


        }
    }
}
