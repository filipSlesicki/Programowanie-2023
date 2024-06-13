using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Kamer� ruszamy w LateUpdate
    void LateUpdate()
    {
        if(player == null)
        {
            return;
        }
        //Ustawiamy kamer� w podanej odleg�o�ci od gracza
        transform.position = player.position - offset;
    }

    [ContextMenu("Set offset")]
    public void SetOffestToCurrent()
    {
        offset = player.position - transform.position;
    }
}
