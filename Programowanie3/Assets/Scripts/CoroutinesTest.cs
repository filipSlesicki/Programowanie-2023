using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinesTest : MonoBehaviour
{
    public Transform cube;
    public Transform endPoint;
    public float moveSpeed = 2;
    public float rotationSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(CountDown());
        //StartCoroutine(CustomLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LerpToPosition());
        }
    }

    /// <summary>
    /// Move Towards with constant speed (variable time)
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveToPosion()
    {
        while (cube.position != endPoint.position)
        {
            cube.position = Vector3.MoveTowards(cube.position, endPoint.position, moveSpeed * Time.deltaTime);
            cube.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            yield return null; // Czekaj 1 klatkê
        }

        Debug.Log("Reached target");
    }

    /// <summary>
    /// Move to target in constant time (variable speed)
    /// </summary>
    /// <returns></returns>
    IEnumerator LerpToPosition()
    {
        Vector3 startPosition = cube.position;
        Quaternion startRotation = cube.rotation;
        float t = 0;
        while (t < 1)
        {
            t += moveSpeed * Time.deltaTime;
            cube.position = Vector3.Lerp(startPosition, endPoint.position, t);
            cube.rotation = Quaternion.Slerp(startRotation, endPoint.rotation, t);
            yield return null;
        }
    }

    //IEnumerator FakeLerp()
    //{
    //    while(Vector3.Distance(cube.position, endPosition.position) > 0.001f)
    //    {
    //        cube.position = Vector3.Lerp(cube.position, endPosition.position, speed * Time.deltaTime);
    //        yield return null;
    //    }
    //    cube.position = endPosition.position;
    //}

    IEnumerator CustomLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Debug.Log(Time.time);
        }
    }

    IEnumerator CountDown()
    {
        Debug.Log(3);
        yield return new WaitForSeconds(1);
        Debug.Log(2);
        yield return new WaitForSeconds(1);
        Debug.Log(1);
        yield return new WaitForSeconds(1);
        Debug.Log("Go!");
    }
}
