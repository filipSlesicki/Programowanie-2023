using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Kamerê ruszamy w LateUpdate
    void LateUpdate()
    {
        if(player == null)
        {
            return;
        }
        //Ustawiamy kamerê w podanej odleg³oœci od gracza
        transform.position = player.position - offset;
    }

    [ContextMenu("Set offset")]
    public void SetOffestToCurrent()
    {
        offset = player.position - transform.position;
    }
}
