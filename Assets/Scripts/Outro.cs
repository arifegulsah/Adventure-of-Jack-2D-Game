using UnityEngine;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    //Bu script ile credits sayfam�z son bulunca ana menu a��lacakt�r

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
