using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] Transform spawnLocation;
    [SerializeField] float spawnRate = 3;
    private float timer;
    //float nextSpawnTime;

    void Start()
    {
        //InvokeRepeating("Spawn", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Time.time >= nextSpawnTime)
        //{
        //    Spawn();
        //    nextSpawnTime = Time.time + spawnRate;
        //}
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Spawn();
            timer = spawnRate;
        }
    }
    
    void Spawn()
    {
        Vector3 randomSpawnPosition = new Vector3(
                                        Random.Range(-20f, 20f),
                                        0,
                                        Random.Range(-10f, 10f));

        // Select random enemy
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
    }
}
