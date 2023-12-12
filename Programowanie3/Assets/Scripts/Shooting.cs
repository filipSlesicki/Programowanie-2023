using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootRate = 1;
    private float shootTimer;

    void Update()
    {
        shootTimer -= Time.deltaTime;
    }

    public void Shoot()
    {
        if(shootTimer < 0)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            shootTimer = shootRate;
        }

    }
}
