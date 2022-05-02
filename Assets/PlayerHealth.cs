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
        //BURDA ACABA ��E YARIYOR MU D�YE H TUSUNA BASINCA HEALTHBARIN AZALIP AZALMADIGINI KONTORL ETT�M
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
        */
        
    }

    //Player hasar ald�k�a can�n�n azalmas�n� sa�layan fonksiyon
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
