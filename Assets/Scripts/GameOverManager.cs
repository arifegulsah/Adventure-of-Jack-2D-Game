
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    //Bu script arac�l��� ile GameOver men�m�z�n istedi�imiz zaman enable istedi�imiz zaman disable olmas�n� sa�layaca��z
    //Yani basit�e karakter �rne�in �ld��� zaman ya da esc tu�una falan bas�ld��� zaman bu men� g�r�n�r olucak ve arka planda oyun duracak.
    //Yani bu scripti PlayerHealth.cs file�m�zda �a��raca��z. Bunu yine instance kulllanarak yapaca��z.
    //Player Death() fonskiyonu �al���nca bu da ard�ndan gelecek ki ekran kars�m�za ��km�� olsun... Bu kadar basit asl�nda.

    //GameOverMenum�z �z�nde bir game objecttir. Onu aray�zden s�r�kle b�rak yapmak i�in ilk i� bir public de�i�ken olu�tural�m.
    public GameObject gameOverUI;

    //instance�m�z
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla GameOverManager �rne�i var!!!");
            return;
        }
        instance = this;
    }

    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        //yield return new WaitForSeconds(2f);
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
