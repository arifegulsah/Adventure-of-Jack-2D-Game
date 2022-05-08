using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    //Bir sahneden yani seviyeden/mapten di�erine ge�erken �nceki mapten kalma de�erlerimizi kay�t alt�nda tutmak i�in bu scripti kullanaca��z

    public GameObject[] objects;

    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
