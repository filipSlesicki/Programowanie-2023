using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{

    public Transform cube1;
    public Transform cubeBlack;
    public float tileWidth = 1f;
    public float tileHeight = 1f;

    public GameObject[] objects;

    public Transform point;
    public float destroyDistance = 5;
    // Start is called before the first frame update
    void Start()
    {
        //int count = 5;
        //while(count > 0)
        //{
        //    Debug.Log(count);
        //    count--;
        //}

        //int targetNumber = 25;
        //int currentNumber = 0;
        //while(currentNumber <= 100)
        //{
        //    if(currentNumber == targetNumber) 
        //    {
        //        Debug.Log(currentNumber);
        //        break;
        //    }
        //    currentNumber++;
        //}
        //int moves = 0;

        //while(cube1.position.x < 10)
        //{
        //    moves++;
        //    cube1.Translate(Vector3.right);
        //}
        //Debug.Log($"Cube moved {moves} times");

        //Debug.Log("Loop over");

        //int j = 0;
        //while(j < 20)
        //{
        //    //code
        //    j++;
        //}

        for (int i = 10; i < 20; i += 3)
        {
            if (i == 16)
            {
                continue;
            }
            Debug.Log(i);
            // code
        }

        int columns = 8;
        int rows = 8;

        Transform[] cubes = new Transform[rows * columns];
        int spawned = 0;
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 spawnPos = new Vector3(x * tileWidth, y * tileHeight, 0);
                Transform cubeToSpawn = (x + y) % 2 == 1 ? cube1 : cubeBlack;
                cubes[spawned] = Instantiate(cubeToSpawn, spawnPos, Quaternion.identity);
                spawned++;
                ////if (x % 2 == 0 && y % 2 != 0 || x % 2 != 0 && y % 2 == 0)
                //if ((x + y) % 2 == 1)
                //{
                //    Instantiate(cube1, spawnPos, Quaternion.identity);
                //}
                //else
                //{
                //    Instantiate(cubeBlack, spawnPos, Quaternion.identity);
                //}
            }
        }

        for (int i = 0; i < cubes.Length; i++)
        {
            Transform item = cubes[i];
            Debug.Log(item.position);
        }

        foreach(Transform item in cubes)
        {
         
            Debug.Log(item.position);
        }

        Transform[] sceneTransforms = FindObjectsByType<Transform>(FindObjectsSortMode.None);

        foreach(Transform sceneTransform in sceneTransforms) 
        {
            if(Vector3.Distance(point.position,sceneTransform.position) < destroyDistance)
            {
                Destroy(sceneTransform.gameObject);
            }
        }
       //GameObject[] players =  GameObject.FindGameObjectsWithTag("Player");
       // foreach (var player in players)
       // {
       //     Destroy(player);
       // }
    }

    bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    bool IsOdd(int number)
    {
        return !IsEven(number);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
