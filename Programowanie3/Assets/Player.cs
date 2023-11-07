using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // modyfikator dostêpu private/public
    public int count = 0;
    public float moveSpeed = 5;
    // Komentarz
    // Start is called before the first frame update
    void Start()
    {
        //typ nazwa = wartoœæ pocz¹tkowa
        //float testFloat = 1f;  
        Debug.Log(count);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = GetMoveDirectionFromKeys();
        //Vector3 moveDirection = GetMoveDirectionFromAxes();
        MoveInDirection(moveDirection);
        Debug.Log(IsPositive(count));
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
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.down;
        }
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        return moveDirection;
    }

    Vector3 GetMoveDirectionFromAxes()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        if (moveDirection.magnitude > 1)
        {
            // Normalize zachowuje kierunek i ustawia d³ugoœæ wektora na 1
            moveDirection.Normalize();
        }
        return moveDirection;
    }

    void MoveInDirection(Vector3 moveDirection)
    {
        //mno¿ymy przez Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê
        //na prêdkoœæ na sekundê
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void DebugSum(int a, int b)
    {
        Debug.Log(a + b);
    }

    int Count()
    {
        return 1 + 2;
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
        return value % 2 == 0;
        int halfValue = value / 2;
        return value == halfValue * 2;
    }


}
