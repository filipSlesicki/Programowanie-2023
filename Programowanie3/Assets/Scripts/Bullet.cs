using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour, projectile
{
    private int damage = 1;
    [SerializeField] private UnityEvent onHit;

    public void Launch(float _speed, float _range, float _dmg)
    {
        this.damage = (int)_dmg;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _speed;
        float lifetime = _range / _speed;
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
