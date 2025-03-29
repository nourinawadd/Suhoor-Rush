using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip countdown;
    public AudioClip gain;
    public AudioClip lose;
    public AudioClip back;
    public AudioClip button;
    public AudioClip menuBg;
    public AudioClip selectionBg;

    public AudioClip gameOver;

    public void PlayMainGameMusic()
    {
        musicSource.Stop();
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySelectionMusic()
    {
        musicSource.Stop();
        musicSource.clip = selectionBg;
        musicSource.Play();
    }

    public void PlayMenuMusic()
    {
        musicSource.Stop();
        musicSource.clip = menuBg;
        musicSource.Play();
    }



    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayGameOverMusic()
    {
        // Ensure the same clip is not replayed
        if (musicSource.isPlaying && musicSource.clip == gameOver)
        {
            Debug.Log("Music is already playing!");
            return;
        }

        musicSource.Stop();
        musicSource.clip = gameOver;
        musicSource.Play();
        Debug.Log("Playing Game Over Music: " + gameOver.name);
    }



}
