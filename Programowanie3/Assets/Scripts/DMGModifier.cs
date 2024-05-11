using UnityEngine;
using System.Collections;

public class DMGModifier : MonoBehaviour
{
    [SerializeField] private int damage = -1;
    public SpeedChangeEffect effect;


    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {

            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Heal(damage);
                
            }
        }
        InvokeRepeating("OnTriggerEnter", 1f, 2f);
    }

    IEnumerator DamageOverTime()
    {
        
        yield return new WaitForSeconds(2f);
        //InvokeRepeating("OnTriggerEnter", 0f, 3f);
    }

    private void Update()
    {
        StartCoroutine("DamageOverTime");
    }
}






