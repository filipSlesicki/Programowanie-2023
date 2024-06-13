using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private bool destroySelfOnHit = true;
    [SerializeField] private bool alwaysMoveForward = false;
    [SerializeField] private UnityEvent onHit;
    private int damage = 1;
    private float speed;
    private Rigidbody rb;
  
    public void Launch(float speed, float range, int damage)
    {
        this.damage = damage;
        rb = GetComponent<Rigidbody>();
        this.speed = speed;
        rb.velocity = transform.forward * speed;
        float lifetime = range / speed;
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        if(alwaysMoveForward)
        {
            // Update velocity to handle direction changes
            rb.velocity = transform.forward * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }
        onHit?.Invoke();

        if(destroySelfOnHit)
        {
            Destroy(gameObject);
        }
    }
}
