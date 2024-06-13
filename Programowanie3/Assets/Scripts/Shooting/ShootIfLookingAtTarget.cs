using UnityEngine;

public class ShootIfLookingAtTarget : MonoBehaviour
{
    [SerializeField] Shooting shooting;
    [SerializeField] LayerMask targetMask;
    [SerializeField] float radius = 1;
    [SerializeField] float coneAngle = 25;
    private string targetTag;
    public void SetTargetTag(string tag)
    {
        targetTag = tag;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
        //Debug.DrawRay(transform.position + transform.right * radius, transform.forward * 100, Color.red);
        //Debug.DrawRay(transform.position - transform.right * radius, transform.forward * 100, Color.red);

        if (Physics.SphereCast(transform.position, radius, transform.forward, out RaycastHit hit, 20, targetMask))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                Debug.Log("target is in front");
                shooting.StartShooting();
                return;
            }
        }
        shooting.StopShooting();

        //Find closest object
        //Collider[] collsInRange = Physics.OverlapSphere(transform.position, radius, targetMask);
        //float shortestDisance = float.MaxValue;
        //Transform closestTransform = null;
        //foreach (Collider collider in collsInRange)
        //{
        //    float distance = Vector3.Distance(transform.position, collider.transform.position);
        //    if (distance < shortestDisance)
        //    {
        //        shortestDisance = distance;
        //        closestTransform = collider.transform;
        //    }
        //}
        //Debug.Log(closestTransform.gameObject.name + "Is the closest object");

        ////Check Cone
        //foreach (Collider collider in collsInRange)
        //{
        //    Vector3 toTarget = collider.transform.position - transform.position;
        //    if(Vector3.Angle(transform.forward,toTarget) < coneAngle)
        //    {
        //        Debug.Log(collider.gameObject.name + " Is in cone range");
        //    }
        //}

        //RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, transform.forward, 20, targetMask);
        //foreach (RaycastHit rayHit in hits)
        //{
        //    Debug.Log(rayHit.collider.gameObject.name);
        //}
    }
}
