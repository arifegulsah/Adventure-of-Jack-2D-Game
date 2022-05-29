using UnityEngine;

public class Cat : MonoBehaviour
{
    public AudioClip catSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(catSound, transform.position);
        }
    }
}
