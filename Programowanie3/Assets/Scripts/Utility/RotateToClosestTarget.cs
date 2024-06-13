using UnityEngine;
using System.Linq;

public class RotateToClosestTarget : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90;
    private Transform target;

    private void Start()
    {
        FindClosestEnemy();    
    }

    private void Update()
    {
        if(target != null)
        {
            Vector3 toTarget = target.position - transform.position;
            Quaternion targetRot = Quaternion.LookRotation(toTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }


    public void FindClosestEnemy()
    {
        target = Enemy.Enemies.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault()?.transform;
    }
}
