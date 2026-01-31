using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Mesero : MonoBehaviour
{
    [SerializeField, TextArea(3, 10)] private string[] dialogueLines;
    [SerializeField] private GameObject exclamacion;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    [SerializeField] int lineIndex;
    private float typingTime = 0.03f;
    private bool spacePressed = false;
    
    public GameObject buttonTalk;
    public GameObject buttonContinue;
    public GameObject buttonQuit;
    public GameObject buttonOponente;
    public bool isDialogueActive = false;
    
    void Start()
    {
        DesactivarAll();
    }

    void Update()
    {
        if (dialogueText.text == dialogueLines[lineIndex])
        {
            if (lineIndex < 3 || lineIndex > 4)
            {
                buttonContinue.SetActive(true);
            }
        }
        if (isDialogueActive)
        {
            spacePressed = Input.GetKey(KeyCode.Space);
        }
        if (isDialogueActive)
        {
            dialoguePanel.SetActive(true);
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
    private float VelocidadEscritura()
    {
        if (spacePressed)
        {
            return 0.005f; 
        }
        else
        {
            return typingTime; 
        }
    }
    IEnumerator Dialogo()
    {
        buttonTalk.SetActive(false);
        buttonContinue.SetActive(false);
        foreach (char letra in dialogueLines[lineIndex])
        {
            dialogueText.text += letra;
            yield return new WaitForSeconds(VelocidadEscritura());
        }
    }

    public void FirstDialogue()
    {
        if (lineIndex < 2)
        {
            lineIndex++;
            dialogueText.text = "";
            //buttonQuit.SetActive(false);
            StartCoroutine(Dialogo());
        }
        else
        {
            dialogueText.text = "";
            buttonContinue.SetActive(false);
            buttonQuit.SetActive(true);
        }
    }
    public void SecondDialogue()
    {
        if (lineIndex > 3 && lineIndex < 5)
        {
            lineIndex++;
            dialogueText.text = "";
            StartCoroutine(Dialogo());
            buttonContinue.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            buttonTalk.SetActive(true);
            exclamacion.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            buttonTalk.SetActive(false);
            exclamacion.SetActive(false);
            buttonQuit.SetActive(false);
        }
    }
    public void ActivarButtonTalk()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        if (dialoguePanel == true)
        {
            StartCoroutine(Dialogo());
            if (lineIndex == 4)
            {
                buttonOponente.SetActive(true);
            }
        }
    }

    public void ActivarButtonQuit()
    {
        DesactivarAll();
        dialogueText.text = "";
        isDialogueActive = false;
    }
    public void DesactivarAll()
    {
        buttonContinue.SetActive(false);
        buttonQuit.SetActive(false);
        buttonTalk.SetActive(false);
        buttonOponente.SetActive(false);
    }
    public void TextoInicial()
    {
        if (lineIndex != 4)
        {
            dialogueText.text = "";
            lineIndex = 4;
            buttonTalk.SetActive(true); 
        }
    }

    public void ActivarButtonOponente()
    {
        lineIndex = 5;
        DesactivarAll();
        dialogueText.text = "";
        StartCoroutine(Dialogo());
    }
}
