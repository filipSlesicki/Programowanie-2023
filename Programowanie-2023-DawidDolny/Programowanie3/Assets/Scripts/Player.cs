using UnityEngine;


public class Player : MonoBehaviour
{
    private Movement movement;
    private Shooting shooting;

    [SerializeField] float rotationSpeed = 60;

    public string someText2 = "Cos22222";
    public string someOtherText = "Cos1111";

    public float someFloat = 2f;
    void Start()
    {
        // Zapisujemy komponenty na tym obiekcie
        movement = GetComponent<Movement>();
        shooting = GetComponent<Shooting>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shooting.Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            shooting.ChangeWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shooting.ChangeWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            shooting.ChangeWeapon(2);
        }

        if(Input.mouseScrollDelta.y > 0)
        {
            shooting.ChangeToNextWeapon();
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            shooting.ChangeToPreviousWeapon();
        }

        LookAtMouse();

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

    private void LookAtMouse()
    {
        Vector2 mousePosition = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * 10, Color.red);

        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            Vector3 lookAtPosition = hit.point;
            lookAtPosition.y = transform.position.y;
            Vector3 lookDirection = lookAtPosition - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
