
using UnityEngine;

public class SoulSound : MonoBehaviour
{
    public AudioClip soulSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(soulSound, transform.position);
        }
    }
}
