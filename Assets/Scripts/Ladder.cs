
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    // Bu scriptimiz sayesinde karakterimizin merdiven gördüðü zaman oluþturduðumuz görünmez bir gameobject ile etkileþime girmesini saðlýyoruz.
    //Sonrasýnda karakterimiz merdivenden yukarý çýkýp aþaðý inebilecektir.

    private bool isInRange; //Merdivenne verdiðim görünmez boxcollider2d'ye deðdi mi deðmedi mi??
    private PlayerMovement playerMovement;
    public BoxCollider2D topCollider; //Burasý merdivenin üst kýsmý
    public Text interactUI; //Etkileþime geçmek için e tuþuna basýnýz textim. enable disable yaparak dilediðim zamanda ekranda görünmesini saðlayacaðým.

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        //Merdivenden aþaðý in
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            Debug.Log("Merdivenden aþaðý iniyorsun");
            return;
        }

        //Merdivenden yukarý çýk
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
            Debug.Log("Merdivenden yukarý çýkýyorsun");
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
            //boxcolliderden ayrýldýðý zaman false yapabilelim ki týrmanýþ animasyonu son bulsun.
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            interactUI.enabled = false;
        }
    }
}
