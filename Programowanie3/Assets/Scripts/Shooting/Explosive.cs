using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float range = 1f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float timeToDestroyExplosion = 1;
    [SerializeField] private bool destroySelf = true;

    public void Explode()
    {
        // Tworzy ekplozjê
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

        explosion.transform.localScale = new Vector3(range * 2, range * 2, range * 2);
        Destroy(explosion, timeToDestroyExplosion);
        //Zadaje obra¿enia wszystkim dooko³a
        Collider[] colsInRange = Physics.OverlapSphere(transform.position, range);
        foreach(Collider col in colsInRange)
        {
            if(col.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);
            }
        }

        if(destroySelf)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
