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
        // Liczymy pocz¹tkow¹ odleg³oœæ od gracza
        offset = player.position - transform.position;
    }

    // Kamerê ruszamy w LateUpdate
    void LateUpdate()
    {
        //Ustawiamy kamerê w podanej odleg³oœci od gracza
        transform.position = player.position - offset;
    }
}
