using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ShootType shootType;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float timeBetweenShots = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 10;
    [SerializeField] private float bulletsSpeed = 1;
    [SerializeField] private int numberOfBullets = 5; 
    [SerializeField] private float spreadAngle = 10f; 
    private float shootTimer;

    void Update()
    {
        shootTimer -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (shootTimer < 0)
        {
            switch (shootType)
            {
                case ShootType.Bullet:
                    for (int i = 0; i < numberOfBullets; i++)
                    {
                        
                        Quaternion spreadRotation = Quaternion.Euler(0, Random.Range(-spreadAngle, spreadAngle), 0) * Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), 0, 0);                        
                        Vector3 shotPosition = shootPoint.position + shootPoint.forward * Random.Range(0.5f, 1f);                        
                        Bullet shotBullet = Instantiate(bulletPrefab, shotPosition, shootPoint.rotation * spreadRotation);
                        shotBullet.Launch(bulletsSpeed, range, damage);
                    }
                    shootTimer = timeBetweenShots;
                    break;
                case ShootType.Ray:                    
                    break;
                default:
                    break;
            }
        }
    }
}
