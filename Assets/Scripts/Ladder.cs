
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    // Bu scriptimiz sayesinde karakterimizin merdiven g�rd��� zaman olu�turdu�umuz g�r�nmez bir gameobject ile etkile�ime girmesini sa�l�yoruz.
    //Sonras�nda karakterimiz merdivenden yukar� ��k�p a�a�� inebilecektir.

    private bool isInRange; //Merdivenne verdi�im g�r�nmez boxcollider2d'ye de�di mi de�medi mi??
    private PlayerMovement playerMovement;
    public BoxCollider2D topCollider; //Buras� merdivenin �st k�sm�
    public Text interactUI; //Etkile�ime ge�mek i�in e tu�una bas�n�z textim. enable disable yaparak diledi�im zamanda ekranda g�r�nmesini sa�layaca��m.

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        //Merdivenden a�a�� in
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            Debug.Log("Merdivenden a�a�� iniyorsun");
            return;
        }

        //Merdivenden yukar� ��k
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
            Debug.Log("Merdivenden yukar� ��k�yorsun");
        }
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
            isInRange = false;
            //boxcolliderden ayr�ld��� zaman false yapabilelim ki t�rman�� animasyonu son bulsun.
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            interactUI.enabled = false;
        }
    }
}
