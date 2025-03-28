using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    public int ObstacleWeight;

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
}
