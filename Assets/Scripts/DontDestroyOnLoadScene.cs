using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    //Bir sahneden yani seviyeden/mapten diðerine geçerken önceki mapten kalma deðerlerimizi kayýt altýnda tutmak için bu scripti kullanacaðýz

    public GameObject[] objects;

    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
