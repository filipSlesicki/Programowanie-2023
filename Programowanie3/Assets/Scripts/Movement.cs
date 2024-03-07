using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    private Rigidbody rb;
    private int directionControl;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        directionControl = 1;
    }

    public void Move(Vector3 moveDirection)
    {
        //mno¿ymy przez Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê
        //na prêdkoœæ na sekundê
        transform.Translate(moveDirection * moveSpeed * directionControl * Time.deltaTime);
    }

    public void MoveWithForce(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * moveSpeed * directionControl);
    }

    public void MoveWithVelocity(Vector3 moveDirection)
    {
        rb.velocity = moveDirection * moveSpeed * directionControl;
    }

    public void PathChange(int changeToThis)
    {
        directionControl = changeToThis;
    }
}
