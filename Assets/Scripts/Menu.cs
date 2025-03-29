using UnityEngine;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour 
{
    AudioManager audioManager;
    public void startGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void select_character()
    {
        audioManager.PlaySFX(audioManager.button);
        SceneManager.LoadScene("Selection");
    }

    public GameObject how_to_play_UI;

    public void how_to_play()
    {
        audioManager.PlaySFX(audioManager.button);
        how_to_play_UI.SetActive(true);
    }


    public void close_how_to_play()
    {
        audioManager.PlaySFX(audioManager.button);
        how_to_play_UI.SetActive(false);
    }

    public GameObject creditsUI;

    public void credits()
    {
        audioManager.PlaySFX(audioManager.button);
        creditsUI.SetActive(true);
    }

    public void close_credits()
    {
        audioManager.PlaySFX(audioManager.button);
        creditsUI.SetActive(false);
    }

    public void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager.PlayMenuMusic();
    }

    
}