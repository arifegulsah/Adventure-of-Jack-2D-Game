using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public bool scriptActive = true;
    //Destroy etmek istediðimiz kodu yazarken Destroy(transform.parent.parent.gameObject); bu þekilde yazabiliriz.
    //Ama bu parent üstü parent þeklinde yazmak iþi çok uzatacaðý için bir deðiþken oluþturuyoruz. Ve bu deðiþkeni arayüz aracýlýðý ile düþmanla eþleþtiriyoruz.
    public GameObject objectToDestroy;

    public AudioClip killSnakeSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player ile çarpýþýrsa yok edecek olan condition burada Tag kullandýðýmýz için Player gameobjectimize arayüzden Player etiketi veriyoruz ki tanýsýn
        //Biz istersek kendimizde default gelenlerin yerine farklý taglerde verebiliriz arayüzden add yapýp

        if (scriptActive)
        {
            if (collision.CompareTag("Player"))
            {
                AudioManager.instance.PlayClipAt(killSnakeSound, transform.position);
                Destroy(objectToDestroy);
            }
        }
        


        /* HANGÝSÝ DOÐRU????
         if (collision.tranform.CompareTag("Player"))
            {
                Destroy(objectToDestroy);
            }
         */
    }

    public void SetScripActive(bool latestValue)
    {
        scriptActive = latestValue;
    }
}
