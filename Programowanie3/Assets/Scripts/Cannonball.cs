using UnityEngine;
using UnityEngine.Events;

public class Cannonball : MonoBehaviour
{
    private int damage = 1;
    public GameObject Impact;
    [SerializeField] private UnityEvent onHit;

    public void Launch(float speed, float range, int damage)
    {
        Impact = Object.Instantiate(Impact);
        this.damage = damage;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed + transform.up * speed * 2;
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

    private void Update()
    {
        RaycastHit Hit;
        Physics.Raycast(transform.position, Vector3.down, out Hit);

        Impact.transform.position = Hit.point;
    }
}