using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Header("Common Weapon Data")]
    [SerializeField] ShootType shootType;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float timeBetweenShots = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 10;
    [SerializeField] private int shootCount = 1;
    [Range(0, 360)]
    [Tooltip("Spread over 180 can hit player!")]
    [SerializeField] private float spread;
    [Header("ShootType Weapon Data")]
    [SerializeField] WeaponBulletSettings bulletSettings;
    [SerializeField] WeaponSpawnSettings spawnObjectSettings;
    [SerializeField] WeaponRaycastSettings raycastSettings;
    [SerializeField] SubweaponSettings subweaponSettings;
    [Header("Shoot Events")]
    [SerializeField] private UnityEvent StartShootingEvent;
    [SerializeField] private UnityEvent StopShootingEvent;
    [SerializeField] private UnityEvent ShootEvent;

    private float shootTimer;
    private bool isShooting;
    private string targetTag = "Enemy";

    public void SetTargetTag(string tag)
    {
        targetTag = tag;
    }

    public void StartShooting()
    {
        isShooting = true;
        StartShootingEvent?.Invoke();
    }

    public void StopShooting()
    {
        isShooting = false;
        StopShootingEvent?.Invoke();
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if (isShooting && shootTimer < 0)
        {
            for (int i = 0; i < shootCount; i++)
            {
                Shoot();
            }
            shootTimer = timeBetweenShots;
        }
    }

    public void Shoot()
    {
        // TODO: Use inheritance instead
        switch (shootType)
        {
            case ShootType.Bullet:
                Bullet shotBullet = Instantiate(bulletSettings.bulletPrefab, shootPoint.position, GetShotRotation());
                shotBullet.Launch(bulletSettings.bulletsSpeed, range, damage);
                break;
            case ShootType.Spawn:
                Instantiate(spawnObjectSettings.prefabToSpawn, shootPoint.position, GetShotRotation());
                break;
            case ShootType.Ray:
                Vector3 shootDirection = GetShotRotation() * Vector3.forward;
                if (Physics.Raycast(shootPoint.position, shootDirection, out RaycastHit hit, range))
                {
                    if (hit.collider.TryGetComponent(out Health health))
                    {
                        health.TakeDamage(damage);
                    }
                    raycastSettings.RayEndPoisitionEvent?.Invoke(hit.point);
                    raycastSettings.HitObjectEvent?.Invoke(hit.collider.gameObject);
                }
                else
                {
                    raycastSettings.RayEndPoisitionEvent?.Invoke(shootPoint.position + shootDirection * range);
                }
                
                break;
            case ShootType.AllInRange:
                Collider[] collidersInRange = Physics.OverlapSphere(shootPoint.position, range);
                foreach (Collider collider in collidersInRange)
                {
                    // Check if it's a valid target
                    if (collider.CompareTag(targetTag) && collider.TryGetComponent(out Health health))
                    {
                        Vector3 toTargetDirection = collider.transform.position - shootPoint.position;
                        if (spread > 0 && Vector3.Angle(shootPoint.forward, toTargetDirection) > spread)
                        {
                            // if we use spread, only damage targets in cone of spread angle in front of weapon
                            continue;
                        }
                        health.TakeDamage(damage);
                        raycastSettings.HitObjectEvent?.Invoke(health.gameObject);
                    }
                }
                break;
                break;
            case ShootType.SubWeapons:
                foreach(Weapon subweapon in subweaponSettings.weapons)
                {
                    subweapon.Shoot();
                }
                break;
            default:
                Debug.LogWarning("Unimplemented weapon type");
                break;
        }
        ShootEvent?.Invoke();
    }

    private Quaternion GetShotRotation()
    {
        Quaternion spreadOffset = Quaternion.Euler(0, Random.Range(-spread / 2, spread / 2), 0); // Obracamy w osi Y
        return shootPoint.rotation * spreadOffset; // Mno¿enie quaternionów dodaje rotacje

    }
}
