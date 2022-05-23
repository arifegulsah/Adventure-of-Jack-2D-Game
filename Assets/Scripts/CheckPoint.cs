using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Bu script ile karakterimiz öldüðü zaman devamlý devamlý baþlangýç noktasýnda spawn olmasý yerine
    //Check point noktalarýnda yani öldüðü yere daha yakýn kýsýmlarda spawn olmasýný saðlýyoruz.

    private Transform playerSpawn;

    public AudioClip flagSound;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(flagSound, transform.position);
            playerSpawn.position = transform.position;
            //Burda destroy ederek bir sonraki check pointin daha powerfull olmasýný saðlýyoruz
            //Yoksa oyuncu 2. checkpointi elde ettikten sonra tekrar bir önceki checkpoint ile temas ederse 1. check point devreye girer 
            //Bunu yapabilmek için direkt Destroy(gameObject); yazabiliriz. Ama eðer böyle yaparsak checkpoint isimli nesneye verdiðimiz her þey kaybolacaktýr.
            //Yani ben check pointin görsel olarak bayrak olmasýný istiyorum. Dokunduðum zaman bayrak kaybolur.
            //Bayrak kaybolsun istemiyorum. Sadece check pointin boxcolliderýinin kaybolmasýný istiyorum.
            //Bu da ayrý bir detaydýr!!
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
