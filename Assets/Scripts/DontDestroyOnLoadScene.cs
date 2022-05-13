using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    //Bir sahneden yani seviyeden/mapten diðerine geçerken önceki mapten kalma deðerlerimizi kayýt altýnda tutmak için bu scripti kullanacaðýz

    public GameObject[] objects;

    //instanceýmýz
    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla DontDestroyOnLoadScene örneði var!!!");
            return;
        }
        instance = this;

        //objelerimizi taþýyan döngü
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }


    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
