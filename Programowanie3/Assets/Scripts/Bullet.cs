using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    private int damage = 1;
    [SerializeField] private UnityEvent onHit;

    public void Launch(float speed, float range, int damage)
    {
        this.damage = damage;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        float lifetime = range / speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }
        onHit?.Invoke();
        Destroy(gameObject);
    }
}
