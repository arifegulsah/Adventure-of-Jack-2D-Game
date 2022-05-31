using UnityEngine;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    //Bu script ile credits sayfamýz son bulunca ana menu açýlacaktýr

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
