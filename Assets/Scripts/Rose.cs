using UnityEngine;
using UnityEngine.Audio;

public class Rose : MonoBehaviour

{

    public AudioClip firstMapEnd;

    public AudioSource deneme; 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            deneme = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
            Debug.Log(deneme);

            AudioManager.instance.playlist[0] = firstMapEnd;

            //deneme.enabled = false;
            //deneme.enabled = true;
            //deneme.clip = firstMapEnd;
            deneme.PlayOneShot(firstMapEnd);
            //deneme.Play();
        }     
    }
}