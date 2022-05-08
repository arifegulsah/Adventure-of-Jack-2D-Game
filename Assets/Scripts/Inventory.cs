
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Bu script sayesinde envanterlerimizin içeriklerini görebileceðiz.
    // Örneðin para toplandýysa bu scripte eriþim saðlanacak ve buradaki para deðeri artýrýlacak.
    // Bu sayede oyuncu paralarý aldýðý zaman artýþ olduðunu ekranýn sað üst köþesinde görebilecek gibi gibi

    // Toplam para amountum ve textim
    public int coinsCount;
    public Text coinsCountText;


    // Her yerden eriþim saðlanabilen static deðiþkenimiz.
    public static Inventory instance;

    //Awake fonksiyonu sayesinde oyun ayaða kalkar kalmaz çalýþacak/etkinleþecek.
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla Inventory örneði var!!!");
            return;
        }
        instance = this;
    }
 
    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }
}
