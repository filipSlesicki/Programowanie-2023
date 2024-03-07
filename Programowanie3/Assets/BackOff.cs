using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOff : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float timeBetweenShots = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 10;


    public void MoveBack(Vector3 shootpos)
    {
        RaycastHit[] hits = Physics.SphereCastAll(shootpos, range,
            (Vector2)transform.position, 0f);

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.GetComponent<Enemy>())
                {
                    RaycastHit hit = hits[i];

                    Movement em = hit.transform.GetComponent<Movement>();
                    em.PathChange(-1);

                    StartCoroutine(ResetPathDirection(em));
                }
            }
        }
    }

    private IEnumerator ResetPathDirection(Movement em)
    {
        yield return new WaitForSeconds(2);

        em.PathChange(1);
    }
}
