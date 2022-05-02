using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        /*
        //BURDA ACABA ÝÞE YARIYOR MU DÝYE H TUSUNA BASINCA HEALTHBARIN AZALIP AZALMADIGINI KONTORL ETTÝM
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
        */
        
    }

    //Player hasar aldýkça canýnýn azalmasýný saðlayan fonksiyon
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
