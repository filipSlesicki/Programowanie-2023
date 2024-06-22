using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Lista fal przeciwnik�w
    [SerializeField] private EnemyWave[] waves;
    [SerializeField] float spawnRate = 30;
    private float timer;
    private int currentWave = 0;
    public static EnemySpawner Instance; // Singleton
    //float nextSpawnTime;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        //InvokeRepeating("Spawn", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.EnemyCount == 0)
        {
            Spawn();
        }
        //if(Time.time >= nextSpawnTime)
        //{
        //    Spawn();
        //    nextSpawnTime = Time.time + spawnRate;
        //}
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        if (currentWave >= waves.Length)
        {
            Debug.Log("No more waves");
            return;
        }
        timer = spawnRate;
        //Stw�z nast�pn� fal�
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
