using UnityEngine;

public class Sweets : MonoBehaviour
{
    public int ScoreWeight;

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
