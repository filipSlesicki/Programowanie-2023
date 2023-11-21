using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Komentarz
    // modyfikator dostêpu private/public
    public int count = 0;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private int health = 3;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image healthbar;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootRate = 1;
    private float shootTimer;
    private Rigidbody rb;

    //typ nazwa = wartoœæ pocz¹tkowa
    //float testFloat = 1f;  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootRate;
            }

        }
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
        if (other.gameObject.CompareTag("HealthPack"))
        {
            Heal(1);
            Destroy(other.gameObject);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHealthUI();
        if (health <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    public void TakeDamagePercentage(float percentage)
    {
        float damge = health * percentage / 100;
        TakeDamage(Mathf.RoundToInt(damge));
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthText.text = $"Health {health}";
        healthbar.fillAmount = (float)health / maxHealth;
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
        else if (value < 0)
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
