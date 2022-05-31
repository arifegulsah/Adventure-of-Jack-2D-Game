using UnityEngine;

public class CreepyCat : MonoBehaviour
{
    public AudioClip windSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(windSound, transform.position);
        }
    }
}
