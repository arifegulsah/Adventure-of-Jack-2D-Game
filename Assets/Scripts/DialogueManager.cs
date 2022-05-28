using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public static DialogueManager instance;
    //Awake fonksiyonu sayesinde oyun ayaða kalkar kalmaz çalýþacak/etkinleþecek.
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla DialogueManager örneði var!!!");
            return;
        }
        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialogue(Diyalogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() //public olmazsa atayamayýz arayüzden
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
