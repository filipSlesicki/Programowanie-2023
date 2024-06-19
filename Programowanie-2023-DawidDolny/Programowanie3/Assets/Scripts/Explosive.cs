using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float range = 1f;
    [SerializeField] private int damage = 1;

    public void Explode()
    {
        // Tworzy ekplozjê
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 2);
        //Zadaje obra¿enia wszystkim dooko³a
        Collider[] colsInRange = Physics.OverlapSphere(transform.position, range);
        foreach(Collider col in colsInRange)
        {
            if(col.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
