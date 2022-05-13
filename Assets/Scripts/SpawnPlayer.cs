
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    //karakterimiz yeni scenede doðarken baþlangýç noktasýnda doðmasýný istiyoruz.
    
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
