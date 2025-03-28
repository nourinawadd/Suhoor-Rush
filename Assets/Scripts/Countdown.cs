using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    public TextMeshProUGUI countdownText;
    AudioManager audioManager;
    bool countdownPlayed = false;

    void Start()
    {
        currentTime = startingTime;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0") + "s Left";

        if (Mathf.Floor(currentTime) == 5 && !countdownPlayed)
        {
            audioManager.PlaySFX(audioManager.countdown);
            countdownPlayed = true; 
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
