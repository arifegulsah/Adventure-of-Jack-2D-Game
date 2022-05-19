using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex;

    void Start()
    {
        //müziði yükle ve play ile çal
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    void Update()
    {
        //devamlý kontrol amaçlý update fonskiyonu
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

}
