
using UnityEngine;

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
        }
    }
}
