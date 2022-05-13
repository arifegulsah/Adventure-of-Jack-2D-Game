using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    // bu script ile herhangi bir objeyi alabilece�iz.
    // coin ve kalp objelerini alaraktan para ve sa�l�k kazanaca��z gibi
    // bahsi ge�en objelerin aray�zde isTrigger se�ene�inin aktif olmas� gerekmektedir.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //e�er collision Player tagli elementle etkile�ime girerse? yani ana karakterimiz paraya/kalbe de�erse
        //scripti verdi�imiz obje (coin ya da kalp art�k neyse) kendini yok eder.
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
