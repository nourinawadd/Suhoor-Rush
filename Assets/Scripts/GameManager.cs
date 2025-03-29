using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    private int highscore;
    public Player player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countdownText;
    public GameObject gameOverPanel;
    AudioManager audioManager;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameHierarchy;
    private CameraMovement cameraMovement;

    public void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        cameraMovement = gameHierarchy.GetComponent<CameraMovement>();
        Play();
    }

    public void ClearSpawners()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        for (int i = 0; i < obstacles.Length; i++){
            Destroy(obstacles[i].gameObject);
        }
        Sweets[] sweets = FindObjectsOfType<Sweets>();
        for (int i = 0; i < sweets.Length; i++){
            Destroy(sweets[i].gameObject);
        }
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);
        countdownText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        player.enabled = true;

        Invoke("ClearSpawners", 0f);
    }

    public void GameOver()
    {
        InvokeRepeating("ClearSpawners", 0.0f, 0.01f);

        player.enabled = false;
        countdownText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);

        audioManager.PlayGameOverMusic();

        // display highscore
        if(score >= highscore)
        {
            highscore = score;
        }
        currentScoreText.text = "Score: " + score.ToString();
        highScoreText.text = "Highscore: " + highscore.ToString();
    }

    public void IncreaseScore(int Score_Weight)
    {
        score += Score_Weight;
        scoreText.text = score.ToString();
    }

    public void DecreaseScore(int Score_Weight)
    {
        score -= Score_Weight;
        scoreText.text = score.ToString();
    }

    public void Replay()
    {
        // Reset player position and state
        gameHierarchy.transform.position = Vector3.zero;
        player.enabled = true;
        cameraMovement.cameraSpeed = 12f;
        player.OnEnable();

        // Reset score and UI
        score = 0;
        scoreText.text = score.ToString();

        // Reset UI visibility
        gameOverPanel.SetActive(false);
        countdownText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);

        // Restart countdown if applicable
        Countdown countdown = FindObjectOfType<Countdown>();
        if (countdown != null)
        {
            countdown.ResetCountdown();
        }

        CancelInvoke("ClearSpawners");

        audioManager.Start();
    }

    public int ReturnScore()
    {
        return score;
    }
}
