using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Bu script sayesinde oyun açýlýnca karaþýmýza çýkacak olan oyuna baþla, ayarlar ve oyundan çýk butonlarý gibi nesneleri yöneteceðiz

    public string levelToLoad;

    public GameObject settingsWindow;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
