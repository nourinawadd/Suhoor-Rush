using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager.PlaySelectionMusic();

        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            load();
        }
        UpdateCharacter(selectedOption);
    }

    public void NextOprion()
    {
        audioManager.PlaySFX(audioManager.back);
        selectedOption++;

        if(selectedOption >= characterDatabase.CharacterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        
    }

    public void BackOption()
    {
        audioManager.PlaySFX(audioManager.back);
        selectedOption--;
        if(selectedOption<0)
        {
            selectedOption = characterDatabase.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        
    }

    public void UpdateCharacter(int selectedOption)
    {
        Character character = characterDatabase.GetCharacter(selectedOption);
        artworkSprite.sprite = character.CharacterSprite;
        nameText.text = character.CharacterName;
    }

    private void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
    public void Select()
    {
        audioManager.PlaySFX(audioManager.button);
        Save();
        ChangeScene(0);
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void ReturnOption()
    {
        audioManager.PlaySFX(audioManager.button);
        ChangeScene(0);
    }
    
}
