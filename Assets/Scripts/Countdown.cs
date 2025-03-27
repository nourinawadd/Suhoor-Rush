using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    public TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0") + "s Left";

        if (currentTime <= 0)
        {
            currentTime = 0;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
