using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    // bu script ile herhangi bir objeyi alabileceðiz.
    // coin ve kalp objelerini alaraktan para ve saðlýk kazanacaðýz gibi
    // bahsi geçen objelerin arayüzde isTrigger seçeneðinin aktif olmasý gerekmektedir.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //eðer collision Player tagli elementle etkileþime girerse? yani ana karakterimiz paraya/kalbe deðerse
        //scripti verdiðimiz obje (coin ya da kalp artýk neyse) kendini yok eder.
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
