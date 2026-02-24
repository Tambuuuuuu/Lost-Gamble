using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lineas;
    public float textSpeed = 0.05f;

    private int index;
    public bool hablando { get; private set; }

    void Start()
    {
        textComponent.text = string.Empty;
        hablando = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!hablando) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lineas[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lineas[index];
            }
        }
    }

    public void StarDialogo()
    {
        StopAllCoroutines();
        index = 0;
        textComponent.text = string.Empty;
        hablando = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lineas[index])
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lineas.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = string.Empty;
            index = 0;
            hablando = false;
            gameObject.SetActive(false);
        }
    }
}
