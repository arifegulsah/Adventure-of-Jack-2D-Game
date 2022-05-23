using UnityEngine;
using UnityEngine.UI;

public class ChestUseless : MonoBehaviour
{


    private Text interactUI;
    public Text bosBirSandikMi;

    private bool isInRange = false;


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
            interactUI.enabled = false;
            isInRange = false;
            bosBirSandikMi.enabled = false;
        }
    }

}
