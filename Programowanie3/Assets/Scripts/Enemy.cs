using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player target;
    public float moveSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = target.transform.position - transform.position;
        moveDirection.Normalize();
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage();
        }
    }
}
