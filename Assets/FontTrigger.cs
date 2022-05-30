using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontTrigger : MonoBehaviour
{
    //public Canvas myCanvas;

    private Text deneme;
    private Text deneme2;

    public Font yeniFont;

    void Start()
    {
        deneme = GameObject.FindGameObjectWithTag("ForFont").GetComponent<UnityEngine.UI.Text>();
        deneme2 = GameObject.FindGameObjectWithTag("ForFont2").GetComponent<UnityEngine.UI.Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            deneme.font = yeniFont;
            deneme2.font = yeniFont;
        }
    }
}
