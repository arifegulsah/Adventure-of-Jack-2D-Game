using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //karakter düþmana bir kere çarptýðý zaman cool down olsun ki devamlý devamlý çarpýp ölmesin caný azalmasýn
    //vereceðim delayýda aþaðýdaki deðiþkende tutuyorum.
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
        
        //BURDA ACABA ÝÞE YARIYOR MU DÝYE H TUSUNA BASINCA HEALTHBARIN AZALIP AZALMADIGINI KONTORL ETTÝM
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
        
        
    }

    //Player hasar aldýkça canýnýn azalmasýný saðlayan fonksiyon
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
            //1f dediði rgbdeki 255 deðer aslýnda 0f dediði de 0 deðeri oluyor, R G B ve Opacity deeðrleri verdim burada
            graphics.color = new Color(1f, 1f, 1f, 0f);

            //þimdi karakter snakee çarptýðý zaman yanýp sönmesini istiyorum. bunun için opacity 0f ile 1f arasýnda deðiþmeli
            //bu deðiþimi gözle görebilmek için araya bir delay vericem bu sayede yanýp söylüyor gibi olucak
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
