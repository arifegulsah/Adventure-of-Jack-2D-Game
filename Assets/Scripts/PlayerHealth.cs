using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //karakter d��mana bir kere �arpt��� zaman cool down olsun ki devaml� devaml� �arp�p �lmesin can� azalmas�n
    //verece�im delay�da a�a��daki de�i�kende tutuyorum.
    public bool isInvincible = false;
    public float invincibilityFlashDelay = 0.2f;
    public float invincibilityTimeAfterHit = 2f;

    public SpriteRenderer graphics;

    public HealthBar healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        
        //BURDA ACABA ��E YARIYOR MU D�YE H TUSUNA BASINCA HEALTHBARIN AZALIP AZALMADIGINI KONTORL ETT�M
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
        
        
    }

    //Player hasar ald�k�a can�n�n azalmas�n� sa�layan fonksiyon
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
        
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            //1f dedi�i rgbdeki 255 de�er asl�nda 0f dedi�i de 0 de�eri oluyor, R G B ve Opacity dee�rleri verdim burada
            graphics.color = new Color(1f, 1f, 1f, 0f);

            //�imdi karakter snakee �arpt��� zaman yan�p s�nmesini istiyorum. bunun i�in opacity 0f ile 1f aras�nda de�i�meli
            //bu de�i�imi g�zle g�rebilmek i�in araya bir delay vericem bu sayede yan�p s�yl�yor gibi olucak
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    } 

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
