using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOT : MonoBehaviour, IPoison
{
    [SerializeField] private float poisonTime;

    public bool IsPosioned()
    {
        return true;
    }

    public void SetPosion(float addPoisonTime)
    {
        throw new System.NotImplementedException();
    }

    public void WhilePoison()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<IPoison>(out IPoison p))
        {
            if (!p.IsPosioned())
            {
                p.SetPosion(poisonTime);
            }
        }
    }
}
