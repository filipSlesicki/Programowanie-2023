using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    private float startingSpeed;
    private float temp = 0;
    private Rigidbody rb;
    [SerializeField] private float resetTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingSpeed = moveSpeed;
    }

    public void Return()
    {
         moveSpeed = startingSpeed;
    }

    public void Move(Vector3 moveDirection)
    {
        //mno¿ymy przez Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê
        //na prêdkoœæ na sekundê
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveWithForce(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * moveSpeed);
    }

    public void MoveWithVelocity(Vector3 moveDirection)
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    public void TempMovementSpeed()
    {
        moveSpeed = temp;
        Debug.Log("zero");
        Invoke("Return", resetTime);
    }
}
