using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTAplly : MonoBehaviour
{
    public DOTefect doteffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            Debug.Log("GRACZ");
            DOTScript dot = other.gameObject.AddComponent<DOTScript>();
            dot.Initilize(doteffect);

        }
    }
}
