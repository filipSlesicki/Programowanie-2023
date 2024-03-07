using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ShootType shootType;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float timeBetweenShots = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 10;
    [SerializeField] private float bulletsSpeed = 1;
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
                    GameObject shotBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                    shotBullet.GetComponent<Bullet>().Launch(bulletsSpeed, range, damage);
                    shootTimer = timeBetweenShots;
                    break;
                case ShootType.Ray:
                    bulletPrefab.GetComponent<BackOff>().MoveBack(transform.parent.position);
                    break;
                default:
                    break;
            }
        }
    }
}
