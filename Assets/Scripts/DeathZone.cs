using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    //Bu script ile karakterimiz suya düþtüðünde veya ölümcül bir þeyle ile collision olup,
    //o gameobjecti trigger ettiði zaman ölmesini ve yeniden spawn olmasýný saðlayacaðýz.

    private Transform playerSpawn;
    private Animator fadeSystem;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    //Bu fonskiyonun yaptýðý þey: ekraný karart 1 saniye boyunca bekle ve karakteri sonra replace et böylece oyuncu ýþýnlanma olmuþ gibi hissetmesin.
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn.position;
    }
}
