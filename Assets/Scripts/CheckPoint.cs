using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Bu script ile karakterimiz �ld��� zaman devaml� devaml� ba�lang�� noktas�nda spawn olmas� yerine
    //Check point noktalar�nda yani �ld��� yere daha yak�n k�s�mlarda spawn olmas�n� sa�l�yoruz.

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
            //Burda destroy ederek bir sonraki check pointin daha powerfull olmas�n� sa�l�yoruz
            //Yoksa oyuncu 2. checkpointi elde ettikten sonra tekrar bir �nceki checkpoint ile temas ederse 1. check point devreye girer 
            //Bunu yapabilmek i�in direkt Destroy(gameObject); yazabiliriz. Ama e�er b�yle yaparsak checkpoint isimli nesneye verdi�imiz her �ey kaybolacakt�r.
            //Yani ben check pointin g�rsel olarak bayrak olmas�n� istiyorum. Dokundu�um zaman bayrak kaybolur.
            //Bayrak kaybolsun istemiyorum. Sadece check pointin boxcollider�inin kaybolmas�n� istiyorum.
            //Bu da ayr� bir detayd�r!!
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
