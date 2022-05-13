
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthPoint = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Bu kond�syon sayesinde e�er player�n can� zaten 100 ise kalpleri ortadan kald�rmas�n� engelleyece�iz
            //Yani oyuncu geri d�n�p kalpleri alabilecek can� azald��� zaman
            if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            {
                PlayerHealth.instance.HealPlayer(healthPoint);
                Destroy(gameObject);
            }
        }
    }
}
