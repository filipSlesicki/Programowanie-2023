using System.Collections;
using UnityEngine;

public class SmartDetection : MonoBehaviour
{
    private SphereCollider sphereCol;
    private float range;

    private void OnEnable()
    {
        sphereCol = GetComponent<SphereCollider>();
        range = GetComponentInParent<SmartBullet>().range;
        StartCoroutine(Detect());
    }
    private IEnumerator Detect()
    {
        while (sphereCol.radius * transform.parent.lossyScale.x < range)
        {
            sphereCol.radius += Time.deltaTime * 35;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.6f);
        if (GetComponentInParent<SmartBullet>().target == null)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            GetComponentInParent<SmartBullet>().target = other.GetComponent<Enemy>();
            GetComponentInParent<SmartBullet>().Attack();
            gameObject.SetActive(false);
        }
    }
}
