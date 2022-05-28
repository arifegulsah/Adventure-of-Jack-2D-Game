using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChestUseless : MonoBehaviour
{


    private Text interactUI;
    public Text bosBirSandikMi;

    private bool isInRange = false;

    public AudioClip uselessChestSound;

    public SpriteRenderer chestSpriteRenderer;
    public BoxCollider2D chestBoxCollider;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        bosBirSandikMi = GameObject.FindGameObjectWithTag("bosBirSandikMi").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            bosBirSandikMi.enabled = true;
            interactUI.enabled = false;

            AudioManager.instance.PlayClipAt(uselessChestSound, transform.position);
            //chestSpriteRenderer.color = new Color(1f, 0f, 0f, 0f);
            //Check();
            //StartCoroutine(SpriteRendererDestroy());

        }
    }

    /*
    void Check()
    {
        if (chestSpriteRenderer.color == new Color(1f, 0f, 0f, 0f))
        {
            StartCoroutine(BoxColliderDestroy());
        }
    }
    */

    public IEnumerator SpriteRendererDestroy()
    {
        chestSpriteRenderer.enabled = false;
        yield return new WaitForSeconds(5f);
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
            bosBirSandikMi.enabled = false;
        }
    }

}
