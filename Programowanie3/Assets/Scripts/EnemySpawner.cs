using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Lista fal przeciwników
    [SerializeField] private EnemyWave[] waves;
    [SerializeField] float spawnRate = 30;
    private float timer;
    private int currentWave = 0;
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
        if (currentWave >= waves.Length)
        {
            Debug.Log("No more waves");
            return;
        }
        //Stwóz nastêpn¹ falê
        EnemyWave wave = waves[currentWave];
        for (int i = 0; i<  wave.SpawnCount; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-20f, 20f),0,Random.Range(-10f, 10f));

            // Select random enemy
            Enemy enemyPrefab = wave.PossibleEnemies[Random.Range(0, wave.PossibleEnemies.Length)];
            Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
        }
        currentWave++;
    }
}
