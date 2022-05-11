using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    //Bu script ile karakterimiz suya d��t���nde veya �l�mc�l bir �eyle ile collision olup,
    //o gameobjecti trigger etti�i zaman �lmesini ve yeniden spawn olmas�n� sa�layaca��z.

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

    //Bu fonskiyonun yapt��� �ey: ekran� karart 1 saniye boyunca bekle ve karakteri sonra replace et b�ylece oyuncu ���nlanma olmu� gibi hissetmesin.
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn.position;
    }
}
