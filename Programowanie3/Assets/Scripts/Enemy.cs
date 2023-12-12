using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private int damage = 1;
    Movement movement;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 moveDirection = target.transform.position - transform.position;
            moveDirection.Normalize();
            movement.MoveWithVelocity(moveDirection);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health playerHealth = other.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
