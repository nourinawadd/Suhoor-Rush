using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip countdown;
    public AudioClip gain;
    public AudioClip lose;
    public AudioClip gameOver;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayGameOverMusic()
    {
        if (musicSource == null || !musicSource.enabled)
        {
            Debug.LogError("Music Source is missing or disabled!");
            return;
        }

        // Ensure the same clip is not replayed
        if (musicSource.isPlaying && musicSource.clip == gameOver)
        {
            Debug.Log("Game Over music is already playing!");
            return;
        }

        musicSource.Stop();
        musicSource.clip = gameOver;
        musicSource.Play();
        Debug.Log("Playing Game Over Music: " + gameOver.name);
    }



}
