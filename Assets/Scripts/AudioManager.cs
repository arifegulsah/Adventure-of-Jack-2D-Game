using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex;

    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance;

    //Awake fonksiyonu sayesinde oyun ayaða kalkar kalmaz çalýþacak/etkinleþecek.
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla AudioManager örneði var!!!");
            return;
        }
        instance = this;
    }


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

    //objelerimiz toplandýðý zaman anlýk ses çalmasý için oluþturduðumuz fonksiyon. instance kullanarak diðer filelardan çaðýracaðýz
    //ki devamlý devalý ayný kodu yazmayalým
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
