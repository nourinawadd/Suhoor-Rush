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

    public CharacterDatabase characterDatabase;
    private int selectedOption = 0;
    void Awake()
    {
        if (selectedOption == 0)
        {
            spriteIndex = 0;

        }
        else
        {
            spriteIndex = 5;
        }
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            load();
        }
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
        if(selectedOption==0)
        {
            if (spriteIndex >= 4)
            {
                spriteIndex = 0;
            }

            spriteRenderer.sprite = sprites[spriteIndex];
        }
        else if (selectedOption == 1)
        {
            
            if (spriteIndex >= 9)
            {
                spriteIndex = 5;
            }

            spriteRenderer.sprite = sprites[spriteIndex];
        }

    }

  

    private void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
