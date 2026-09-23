using UnityEngine;

public class AudioService : MonoBehaviour, IAudioService
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip catchClip;
    [SerializeField] AudioClip loseLifeClip;
    [SerializeField] AudioClip gameOverClip;

    public void Play(Sound sound)
    {
        AudioClip clip = null;

        switch (sound)
        {
            case Sound.Catch:
                clip = catchClip;
                break;

            case Sound.LoseLife:
                clip = loseLifeClip;
                break;

            case Sound.GameOver:
                clip = gameOverClip;
                break;
        }

        if (clip != null)
        {
            source.PlayOneShot(clip);
        }

    }
}
