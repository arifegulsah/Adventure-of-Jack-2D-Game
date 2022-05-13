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

    //eri�im sa�lamak ad�na ?????????
    public static PlayerHealth instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla PlayerHealth �rne�i var!!!");
            return;
        }
        instance = this;
    }

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
            TakeDamage(80);
        }
        
        
    }

    //Player heart objesi ile temas ettik�e can�n� art�ran fonksiyon
    public void HealPlayer(int amount)
    {
        //bu ko�ul sanyesinde karakterimizin can� 100'� ge�meyecektir.
        if((currentHealth +amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthBar.SetHealth(currentHealth);
    }


    //Player hasar ald�k�a can�n�n azalmas�n� sa�layan fonksiyon
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //oyuncunun hala hayatta olup olmad���n� kontrol etti�imiz yer. hayatta de�ilse �ld�rece�iz.
            if(currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
        
    }

    //Karakterimiz �ld��� zaman �a��racak oldu�umuz fonksiyon budur
    //Karakterimiz �ld��� zaman oyuncu sa�a sola yukar� a�a��ya hareket ettiremez, ekrandaki di�er itemelrle etkile�im yapamaz ve �l�m animasyonu araya girer.
    //Hareket �zelliklerimiz tamamen PlayerMovement.cs dosyam�zda bulunmakta bu y�zden bu fonksiyon bu dosya ile etkile�im kuracakt�r.
    //Bu ileti�imi yine instance kullanarak yapaca��z.
    //1-Whole scripti devre d��� b�rakaca��z.
    //2-�l�m animasyonunu devreye  sokaca��z
    //3-RigidBody2D 'de bulunan Body Type'� t�pk� Gridde yapt���m�z gibi kinematik yapaca��z ve bu sekilde dokunulmaz hale gelece�iz.
    public void Die()
    {
        Debug.Log("Oyuncu �ld�!!!");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Death");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
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
