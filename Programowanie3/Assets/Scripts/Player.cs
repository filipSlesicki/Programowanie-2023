using UnityEngine;


public class Player : MonoBehaviour
{
    private Movement movement;
    private Shooting shooting;

    void Start()
    {
        movement = GetComponent<Movement>();
        shooting = GetComponent<Shooting>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shooting.Shoot();
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = GetMoveDirectionFromAxes();
        movement.MoveWithVelocity(moveDirection);
    }

    Vector3 GetMoveDirectionFromKeys()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }

        if (moveDirection.magnitude > 1)
        {
            // Normalize zachowuje kierunek i ustawia d³ugoœæ wektora na 1
            moveDirection.Normalize();
        }
        return moveDirection;
    }

    Vector3 GetMoveDirectionFromAxes()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        return moveDirection;
    }
}
