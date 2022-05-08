
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Bu script sayesinde envanterlerimizin i�eriklerini g�rebilece�iz.
    // �rne�in para topland�ysa bu scripte eri�im sa�lanacak ve buradaki para de�eri art�r�lacak.
    // Bu sayede oyuncu paralar� ald��� zaman art�� oldu�unu ekran�n sa� �st k��esinde g�rebilecek gibi gibi

    // Toplam para amountum ve textim
    public int coinsCount;
    public Text coinsCountText;


    // Her yerden eri�im sa�lanabilen static de�i�kenimiz.
    public static Inventory instance;

    //Awake fonksiyonu sayesinde oyun aya�a kalkar kalmaz �al��acak/etkinle�ecek.
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla Inventory �rne�i var!!!");
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
