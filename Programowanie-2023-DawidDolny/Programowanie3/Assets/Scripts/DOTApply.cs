using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTApply : MonoBehaviour
{
    public DOT dot;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            Damage damage = other.gameObject.AddComponent<Damage>();
            damage.startDamage(dot);
        }
    }
}