using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex;

    void Start()
    {
        //m�zi�i y�kle ve play ile �al
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    void Update()
    {
        //devaml� kontrol ama�l� update fonskiyonu
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
