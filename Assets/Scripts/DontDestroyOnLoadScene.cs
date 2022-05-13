using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    //Bir sahneden yani seviyeden/mapten di�erine ge�erken �nceki mapten kalma de�erlerimizi kay�t alt�nda tutmak i�in bu scripti kullanaca��z

    public GameObject[] objects;

    //instance�m�z
    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla DontDestroyOnLoadScene �rne�i var!!!");
            return;
        }
        instance = this;

        //objelerimizi ta��yan d�ng�
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
