using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public Player player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countdownText;
    public GameObject gameOverPanel;

    public void Awake(){
        Play();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);
        countdownText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        player.enabled = true;

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        for (int i = 0; i < obstacles.Length; i++){
            Destroy(obstacles[i].gameObject);
        }
    }

    public void GameOver()
    {
        countdownText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);        
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void DecreaseScore()
    {
        score--;
        scoreText.text = score.ToString();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
