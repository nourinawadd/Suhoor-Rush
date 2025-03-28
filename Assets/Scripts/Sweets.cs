using UnityEngine;

public class Sweets : MonoBehaviour
{
    private GameObject player;

    public int ScoreWeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Sweet")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
