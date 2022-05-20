
using UnityEngine;
using System.Collections;

public class FireEnemy : MonoBehaviour
{
    public int damageFromFire = 10;
    public GameObject fireDestroy;

    public AudioClip fireSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(fireSound, transform.position);
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageFromFire);

            StartCoroutine(ColorChangeRed());
            StartCoroutine(HandleColorChangeDelay());
        }
    }

    public SpriteRenderer charSpriteRenderer;
    public float colorChangeDelay = 0.2f;
    public float colorChangeTimeForColor = 2f;

    public IEnumerator ColorChangeRed()
    {
        charSpriteRenderer.color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(colorChangeDelay);
    }

    public IEnumerator HandleColorChangeDelay()
    {
        yield return new WaitForSeconds(colorChangeTimeForColor);
    }

}
