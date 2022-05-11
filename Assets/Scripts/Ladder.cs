
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Bu scriptimiz sayesinde karakterimizin merdiven gördüðü zaman oluþturduðumuz görünmez bir gameobject ile etkileþime girmesini saðlýyoruz.
    //Sonrasýnda karakterimiz merdivenden yukarý çýkýp aþaðý inebilecektir.

    private bool isInRange; //Merdivenne verdiðim görünmez boxcollider2d'ye deðdi mi deðmedi mi??
    private PlayerMovement playerMovement;
    public BoxCollider2D collider; //Burasý merdivenin üst kýsmý

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
            collider.isTrigger = false;
        }
    }
}
