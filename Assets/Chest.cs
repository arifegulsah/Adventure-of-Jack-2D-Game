using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    // Bu script ile player cheste dokundu�u ve interact olmak istedi�i zaman animasyon oynamas�n� sa�layaca��z ve di�er i�lemler ger�ekle�cek


    private Text interactUI;
    public Text interactEminMisin;

    private bool isInRange = false;

    public Animator animator;

    public int coinsToAdd;

    public AudioClip addCoinSound;

    void Awake()
    {
        interactEminMisin = GameObject.FindGameObjectWithTag("eminMisinText").GetComponent<Text>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

    }

    //inputlar� keydown gibi buraya yaz�yoruz.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            //interactEminMisin.enabled = true;
            OpenChest();
        }
    }

    void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instance.PlayClipAt(addCoinSound, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
            interactEminMisin.enabled = false;
        }
    }
}
