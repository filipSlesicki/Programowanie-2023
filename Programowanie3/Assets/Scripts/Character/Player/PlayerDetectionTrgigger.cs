using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionTrgigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided with player named "+other.gameObject.name);
        }

        Player player = other.GetComponent<Player>();
        if(player != null )
        {

        }


        //if(other.gameObject.name == "Player")
        //{

        //}

        //if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        //{
        //    Debug.Log("player layer");
        //}
  
    }
}
