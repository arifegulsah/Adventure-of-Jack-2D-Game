using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JackSpeech : MonoBehaviour
{
    public Diyalogue dialogue; //Diyalogue sýnýfýmýzdan bir nesne oluþturduk.

    public bool isInRange = false;

    //private Text interactUI;

    private void Awake()
    {
        //interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if (isInRange)
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            //interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            //interactUI.enabled = false;
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
        //interactUI.enabled = false;
    }
}
