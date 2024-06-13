using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private int damage = 1;
    Movement movement;

    public static List<Enemy> Enemies = new List<Enemy>();
    public static int EnemyCount;

    private void Start()
    {
        Enemies.Add(this);
        EnemyCount++;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null )
        {
            target = player.transform;
        }
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

    private void OnDestroy()
    {
        EnemyCount--;
        Enemies.Remove(this);
    }
}
