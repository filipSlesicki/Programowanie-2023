using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTScript : MonoBehaviour
{
    public DOTefect doteffect;
    private float timer;

    public void Initilize(DOTefect effect)
    {
        doteffect = effect;
        timer = 0f;
        InvokeRepeating("Dotaplly", 0f, doteffect.tickTime);
    }


    public void Dotaplly()
    {
        timer += doteffect.tickTime;
        if (timer <= doteffect.time)
        {
            Health health = GetComponent<Health>();

            health.TakeDamage(Mathf.RoundToInt(doteffect.Dmg));

        }
        else
        {
            CancelInvoke("Dotaplly");
            Destroy(this);
        }
         
    }
}
