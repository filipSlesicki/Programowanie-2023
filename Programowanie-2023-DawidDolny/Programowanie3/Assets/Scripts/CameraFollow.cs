using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        // Liczymy pocz�tkow� odleg�o�� od gracza
        offset = player.position - transform.position;
    }

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
}
