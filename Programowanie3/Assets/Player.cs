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
    }

    // Update is called once per frame
    void Update()
    {
        //mno¿ymy przez Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê
        //na prêdkoœæ na sekundê

        //transform.Rotate(0, 60 * Time.deltaTime, 0);
        //Vector3 moveDirection = Vector3.zero;
        //if (Input.GetKey(KeyCode.D))
        //{
        //    moveDirection += Vector3.right;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    moveDirection += Vector3.left;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    moveDirection += Vector3.up;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    moveDirection += Vector3.down;
        //}

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        if (moveDirection.magnitude > 1)
        {
            // Normalize zachowuje kierunek i ustawia d³ugoœæ wektora na 1
            moveDirection.Normalize();
        }
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
