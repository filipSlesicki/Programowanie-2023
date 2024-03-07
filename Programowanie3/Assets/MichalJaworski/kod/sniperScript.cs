using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperScript : MonoBehaviour
{
    [SerializeField] LayerMask enemyMask;
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject explosionPrefab;

    [Header("MarksmanRifleStats")]
    [SerializeField] float maxAmmo = 10f;
    [SerializeField] float currentAmmo;
    [SerializeField] float reloadTime = 3f;
    [SerializeField] float rateOfFire = 100f;
    [SerializeField] int Damage = 3;
    [SerializeField] float fireRange = 20f;
    private float fireTimer = 0f;
    private float reloadTimer = 0f;


    [Header("Wybuch")]
    [SerializeField] int explosionDamage = 1;
    [SerializeField] float explosionRadius;

    private void Awake()
    {
        currentAmmo = maxAmmo;

    }
    void Update()
    {
        fireTimer += Time.deltaTime;
        reloadTimer += Time.deltaTime;

        if (currentAmmo > 0 && fireTimer >= 1f / rateOfFire)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                sniperShoot();
                fireTimer = 0f;
                currentAmmo--;
            }
        }
        else if (currentAmmo <= 0)
        {
            if (reloadTimer >= reloadTime) 
            {
                reloadTimer = 0f;
                StartCoroutine(waitForReload());
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && reloadTimer >= reloadTime)
        {
            reloadTimer = 0f;
            StartCoroutine(waitForReload());
        }
    }

    void sniperShoot()
    {
        RaycastHit sniperHit;
        if (Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out sniperHit, fireRange))
        {
            explode(sniperHit.point);

            Health enemy = sniperHit.collider.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
    
    }

    void reload()
    {
        currentAmmo = maxAmmo;
    }

    void explode(Vector3 explosionPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius, enemyMask);

        Debug.Log("Number of colliders in explosion radius: " + colliders.Length);

        foreach (Collider hitCollider in colliders)
        {
            Health enemyHealth = hitCollider.GetComponent<Health>();
            if (enemyHealth != null)
            {
                // Apply damage to the enemy
                enemyHealth.TakeDamage(explosionDamage);
                Debug.Log("Applied damage to an enemy!");
            }
        }


        Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
    }

    IEnumerator waitForReload()
    {
        yield return new WaitForSeconds(reloadTime);
        reload();
    }
}
