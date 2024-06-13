using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysShoot : MonoBehaviour
{
    Shooting shooting;
    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<Shooting>();
        shooting.StartShooting();
    }
}
