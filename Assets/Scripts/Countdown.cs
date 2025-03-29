/* using UnityEngine;
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
*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float startingTime = 3f;
    private float currentTime;
    private bool isCounting = false;
    private AudioManager audioManager;
    bool countdownPlayed = false;
    public Image countdownFill;
    public Image countdownFillRed;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio")?.GetComponent<AudioManager>();
        ResetCountdown();
    }

    private void Update()
    {
        if (isCounting)
        {
            currentTime -= 1 * Time.deltaTime;
            //countdownText.text = currentTime.ToString("0") + "s Left";
            countdownFill.fillAmount = currentTime / startingTime;
            countdownFillRed.fillAmount = currentTime / startingTime;

            if (Mathf.Floor(currentTime) == 5 && !countdownPlayed)
            {
                Debug.Log("Start alert");
                countdownFill.enabled = false;
                countdownFillRed.enabled = true;
                countdownFillRed.fillAmount = currentTime / startingTime;
                audioManager.PlaySFX(audioManager.countdown);
                countdownPlayed = true; 
            }

            if (currentTime <= 0)
            {
                currentTime = 0;
                isCounting = false;
                FindObjectOfType<GameManager>().GameOver();
                Debug.Log("Countdown Complete!");
            }
        }
    }

    // Call this to restart the countdown
    public void ResetCountdown()
    {
        currentTime = startingTime;
        isCounting = true;
        if (countdownFill != null)
            countdownFill.fillAmount = 1f;
        countdownFill.enabled = true;
        countdownPlayed = false;
    }

    public float GetTime()
    {
        return currentTime;
    }
}
