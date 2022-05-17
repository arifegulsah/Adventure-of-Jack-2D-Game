using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public bool scriptActive = true;
    //Destroy etmek istedi�imiz kodu yazarken Destroy(transform.parent.parent.gameObject); bu �ekilde yazabiliriz.
    //Ama bu parent �st� parent �eklinde yazmak i�i �ok uzataca�� i�in bir de�i�ken olu�turuyoruz. Ve bu de�i�keni aray�z arac�l��� ile d��manla e�le�tiriyoruz.
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player ile �arp���rsa yok edecek olan condition burada Tag kulland���m�z i�in Player gameobjectimize aray�zden Player etiketi veriyoruz ki tan�s�n
        //Biz istersek kendimizde default gelenlerin yerine farkl� taglerde verebiliriz aray�zden add yap�p

        if (scriptActive)
        {
            Debug.Log("nesne:" + gameObject.name);
            Debug.Log("nesne:" + collision.gameObject.name);

            if (collision.CompareTag("Player"))
            {
                Destroy(objectToDestroy);

            }
        }
        


        /* HANG�S� DO�RU????
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
