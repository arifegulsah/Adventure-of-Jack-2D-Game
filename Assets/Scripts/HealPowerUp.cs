
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthPoint = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Bu kondüsyon sayesinde eðer playerýn caný zaten 100 ise kalpleri ortadan kaldýrmasýný engelleyeceðiz
            //Yani oyuncu geri dönüp kalpleri alabilecek caný azaldýðý zaman
            if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            {
                PlayerHealth.instance.HealPlayer(healthPoint);
                Destroy(gameObject);
            }
        }
    }
}
