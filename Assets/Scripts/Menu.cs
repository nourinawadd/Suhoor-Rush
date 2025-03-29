using UnityEngine;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour 
{
    public void startGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void select_character()
    {
        SceneManager.LoadScene("Selection");
    }

    public GameObject how_to_play_UI;

    public void how_to_play()
    {
        how_to_play_UI.SetActive(true);
    }


    public void close_how_to_play()
    {
        how_to_play_UI.SetActive(false);
    }

    public GameObject creditsUI;

    public void credits()
    {
        creditsUI.SetActive(true);
    }

    public void close_credits()
    {
        creditsUI.SetActive(false);
    }

    

    
}