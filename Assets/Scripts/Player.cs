using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    AudioManager audioManager;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
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
            audioManager.PlaySFX(audioManager.gain);
            Debug.Log("Hit Sweet");
            FindObjectOfType<GameManager>().IncreaseScore(5);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Obstacle")
        {
            if(FindObjectOfType<GameManager>().ReturnScore()!=0)
             {
                audioManager.PlaySFX(audioManager.lose);
                Debug.Log("Hit Obstacle");
                FindObjectOfType<GameManager>().DecreaseScore(5);
                Destroy(other.gameObject);
            }
        }
    }

    private void AnimateSprite()
    {
        spriteIndex ++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
