using UnityEngine;

public class Player : MonoBehaviour
{    
    // Komentarz
    // modyfikator dostêpu private/public
    public int count = 0;
    public float moveSpeed = 5;
    private Rigidbody rb;
    public int health = 3;
    //typ nazwa = wartoœæ pocz¹tkowa
    //float testFloat = 1f;  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(count);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 moveDirection = GetMoveDirectionFromKeys();
        //Vector3 moveDirection = GetMoveDirectionFromAxes();
        //Move(moveDirection);
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = GetMoveDirectionFromAxes();
        MoveWithVelocity(moveDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }

    public void TakeDamage()
    {
        health--;
        if(health<=0)
        {
            Debug.Log("Dead");
        }
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

    void Move(Vector3 moveDirection)
    {
        //mno¿ymy przez Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê
        //na prêdkoœæ na sekundê
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void MoveWithForce(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * moveSpeed);
    }

    void MoveWithVelocity(Vector3 moveDirection)
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    void DebugSum(int a, int b)
    {
        Debug.Log(a + b);
    }

    bool IsPositive(float value)
    {
        return value >= 0;
        if (value > 0)
        {
            return true;
        }
        else if(value < 0)
        {
            return false;
        }
        else
        {
            Debug.Log("Value is 0");
            return true;
        }
    }

    bool IsEven(int value)
    {
        // Modulo operator (%) to reszta z dzielenia
        //Je¿eli wartoœæ dzieli siê przez 2 bez reszty, to jest dodatnia
        return value % 2 == 0;
        int halfValue = value / 2;
        return value == halfValue * 2;
    }

    bool IsOdd(int value)
    {
        return !IsEven(value);
    }
}
