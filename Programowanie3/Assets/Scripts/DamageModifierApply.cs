using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageModifierApply : MonoBehaviour
{
    public DamageOverTime damageovertime;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            Damage damage = other.gameObject.AddComponent<Damage>();
            damage.startDamage(damageovertime);
        }
    }
}