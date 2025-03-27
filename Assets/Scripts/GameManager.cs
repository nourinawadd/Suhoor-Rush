using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public Player player;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        for (int i = 0; i < obstacles.Length; i++){
            Destroy(obstacles[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled  = false;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Pause();        
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
