
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;
    public int coinsPickedUpInThisSceneCount;

    //instance�m�z
    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla CurrentSceneManager �rne�i var!!!");
            return;
        }
        instance = this;
    }
}
