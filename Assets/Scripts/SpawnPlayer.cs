
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    //karakterimiz yeni scenede do�arken ba�lang�� noktas�nda do�mas�n� istiyoruz.
    
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
