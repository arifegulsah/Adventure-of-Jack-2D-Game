using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex;

    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance;

    //Awake fonksiyonu sayesinde oyun aya�a kalkar kalmaz �al��acak/etkinle�ecek.
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla AudioManager �rne�i var!!!");
            return;
        }
        instance = this;
    }


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

    //objelerimiz topland��� zaman anl�k ses �almas� i�in olu�turdu�umuz fonksiyon. instance kullanarak di�er filelardan �a��raca��z
    //ki devaml� deval� ayn� kodu yazmayal�m
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO, clip.length);
        return audioSource;
    }
}
