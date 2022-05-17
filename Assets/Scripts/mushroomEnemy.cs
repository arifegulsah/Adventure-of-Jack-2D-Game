
using UnityEngine;
using System.Collections;

public class mushroomEnemy : MonoBehaviour
{
    public int damageFromMushroom = 40;
    public GameObject mushroomDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("kontrol");
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageFromMushroom);
            Destroy(mushroomDestroy);

            StartCoroutine(ColorChangeRed());
            //StartCoroutine(HandleColorChangeDelay());
            //StartCoroutine(CameraColorChange());
            GameObject.Find("Main Camera").SendMessage("ChangeColor", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("Main Camera").SendMessage("ChangeColor", false);
    }

    public SpriteRenderer charSpriteRenderer;
    public float colorChangeDelay = 5f;
    public float colorChangeTimeForColor = 2f;

    public IEnumerator ColorChangeRed()
    {
        charSpriteRenderer.color = new Color(0f, 1f, 0f, 1f);
        yield return new WaitForSeconds(colorChangeDelay);
    }

    public IEnumerator HandleColorChangeDelay()
    {
        yield return new WaitForSeconds(colorChangeTimeForColor);
    }





    
}
