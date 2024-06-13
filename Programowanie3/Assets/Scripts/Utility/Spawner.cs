using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;


    public void SpawnAtPosition(Vector3 position)
    {
        Instantiate(prefabToSpawn,position,Quaternion.identity);
    }
}
