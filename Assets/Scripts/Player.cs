using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        playerDirection = Vector2.zero;
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sweet")
        {
            Debug.Log("Hit Sweet");
            FindObjectOfType<GameManager>().IncreaseScore(5);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Obstacle")
        {
            if(FindObjectOfType<GameManager>().ReturnScore()!=0)
             {
                Debug.Log("Hit Obstacle");
                FindObjectOfType<GameManager>().DecreaseScore(5);
                Destroy(other.gameObject);
            }
        }
    }
}
