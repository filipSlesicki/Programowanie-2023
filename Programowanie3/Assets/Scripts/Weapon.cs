using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ShootType shootType;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private GameObject flashPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float timeBetweenShots = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 10;
    [SerializeField] private float bulletsSpeed = 1;
    [SerializeField] private float flashTime = 15;
    [SerializeField] private float stateTime = 15;
    [SerializeField] private bool isFlashed = false;
    GameObject movement;

    private float shootTimer;


    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (isFlashed == true)
        {
            movement = GameObject.FindGameObjectWithTag("Enemy");
            movement.GetComponent<Movement>().TempMovementSpeed();
        }
    }

    public void Shoot()
    {
        if (shootTimer < 0)
        {
            switch (shootType)
            {
                case ShootType.Bullet:
                    Bullet shotBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                    shotBullet.Launch(bulletsSpeed, range, damage);
                    shootTimer = timeBetweenShots;
                    break;
                case ShootType.Ray:
                    //Shoot ray
                    break;
                case ShootType.Flash:
                    flashPrefab.SetActive(true);
                    isFlashed = true;
                    shootTimer = timeBetweenShots;
                    Invoke("endOfFlashScreen", flashTime);
                    Invoke("endOfFlashState", stateTime);
                    break;
                default:
                    break;
            }
        }
    }

    public void endOfFlashScreen()
    {
        flashPrefab.SetActive(false);
    }

    public void endOfFlashState()
    {
        isFlashed = false;
    }
}
