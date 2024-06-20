using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    private float damageTimer;
    public float dmg;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("kolizja");
        Health hp = collision.gameObject.GetComponent<Health>();
        StartCoroutine(DmgOverTime(hp, 6f));
    }

    private IEnumerator DmgOverTime(Health hp, float timer)
    {
      
        while (timer >0)
        {
            if (damageTimer < 1)
            {
                damageTimer += Time.deltaTime * dmg;
            }
            else
            {
                damageTimer = 0;
                hp.TakeDamage(1);
            }
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("unheal"); 
    }

}