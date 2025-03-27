using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;

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
        
        if (collision.tag == "Player")
        {
            Debug.Log("Hit Obstacle");
            FindObjectOfType<GameManager>().DecreaseScore();
        }
        
    }
}
