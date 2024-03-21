using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SmartBullet : MonoBehaviour, projectile
{
    public float range;
    private float speed;
    private float dmg;
    private Rigidbody rb;
    private SphereCollider col;
    [SerializeField] private float timeToActivate;
    private TrailRenderer trail;

    public Enemy target;
    private Coroutine currentCorutine;

    public void Launch(float _speed, float _range, float _dmg)
    {
        dmg = _dmg;
        speed = _speed;
        range = _range;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        timeToActivate += Time.time;
        trail = GetComponentInChildren<TrailRenderer>();
        trail.enabled = false;
        currentCorutine = StartCoroutine(Spawn());
    }

    private void DetectTarget()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Attack()
    {
        if (currentCorutine != null)
        { 
            StopCoroutine(currentCorutine);
        }
        trail.enabled = true;
        currentCorutine = StartCoroutine(AttackTarget());
    }

    private IEnumerator AttackTarget()
    {
        while (target != null &&(transform.position - target.transform.position).magnitude > col.radius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed *2* Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        if (target != null)
        {
            target.GetComponent<Health>().TakeDamage((int)dmg);
        }
        Destroy(gameObject);
        
    }

    private IEnumerator Spawn()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        yield return new WaitUntil(() => Time.time > timeToActivate);

        DetectTarget();
    }
}
