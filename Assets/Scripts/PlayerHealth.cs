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

    //eriþim saðlamak adýna ?????????
    public static PlayerHealth instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla PlayerHealth örneði var!!!");
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
        
        //BURDA ACABA ÝÞE YARIYOR MU DÝYE H TUSUNA BASINCA HEALTHBARIN AZALIP AZALMADIGINI KONTORL ETTÝM
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(80);
        }
        
        
    }

    //Player heart objesi ile temas ettikçe canýný artýran fonksiyon
    public void HealPlayer(int amount)
    {
        //bu koþul sanyesinde karakterimizin caný 100'ü geçmeyecektir.
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


    //Player hasar aldýkça canýnýn azalmasýný saðlayan fonksiyon
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //oyuncunun hala hayatta olup olmadýðýný kontrol ettiðimiz yer. hayatta deðilse öldüreceðiz.
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

    //Karakterimiz öldüðü zaman çaðýracak olduðumuz fonksiyon budur
    //Karakterimiz öldüðü zaman oyuncu saða sola yukarý aþaðýya hareket ettiremez, ekrandaki diðer itemelrle etkileþim yapamaz ve ölüm animasyonu araya girer.
    //Hareket özelliklerimiz tamamen PlayerMovement.cs dosyamýzda bulunmakta bu yüzden bu fonksiyon bu dosya ile etkileþim kuracaktýr.
    //Bu iletiþimi yine instance kullanarak yapacaðýz.
    //1-Whole scripti devre dýþý býrakacaðýz.
    //2-Ölüm animasyonunu devreye  sokacaðýz
    //3-RigidBody2D 'de bulunan Body Type'ý týpký Gridde yaptýðýmýz gibi kinematik yapacaðýz ve bu sekilde dokunulmaz hale geleceðiz.
    public void Die()
    {
        Debug.Log("Oyuncu öldü!!!");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Death");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
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
