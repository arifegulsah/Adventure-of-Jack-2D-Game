
using UnityEngine;

public class Goat : MonoBehaviour
{
    public AudioClip goatSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(goatSound, transform.position);
        }
    }
}
