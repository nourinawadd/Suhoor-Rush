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

    private void Start()
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
        musicSource.Stop();
        musicSource.clip = gameOver;
        musicSource.Play();
    }
}
