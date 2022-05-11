
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Bu scriptimiz sayesinde karakterimizin merdiven g�rd��� zaman olu�turdu�umuz g�r�nmez bir gameobject ile etkile�ime girmesini sa�l�yoruz.
    //Sonras�nda karakterimiz merdivenden yukar� ��k�p a�a�� inebilecektir.

    private bool isInRange; //Merdivenne verdi�im g�r�nmez boxcollider2d'ye de�di mi de�medi mi??
    private PlayerMovement playerMovement;
    public BoxCollider2D collider; //Buras� merdivenin �st k�sm�

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
            //boxcolliderden ayr�ld��� zaman false yapabilelim ki t�rman�� animasyonu son bulsun.
            playerMovement.isClimbing = false;
            collider.isTrigger = false;
        }
    }
}
