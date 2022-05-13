
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    //Bu script aracýlýðý ile GameOver menümüzün istediðimiz zaman enable istediðimiz zaman disable olmasýný saðlayacaðýz
    //Yani basitçe karakter örneðin öldüðü zaman ya da esc tuþuna falan basýldýðý zaman bu menü görünür olucak ve arka planda oyun duracak.
    //Yani bu scripti PlayerHealth.cs fileýmýzda çaðýracaðýz. Bunu yine instance kulllanarak yapacaðýz.
    //Player Death() fonskiyonu çalýþýnca bu da ardýndan gelecek ki ekran karsýmýza çýkmýþ olsun... Bu kadar basit aslýnda.

    //GameOverMenumüz özünde bir game objecttir. Onu arayüzden sürükle býrak yapmak için ilk iþ bir public deðiþken oluþturalým.
    public GameObject gameOverUI;

    //instanceýmýz
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla GameOverManager örneði var!!!");
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
