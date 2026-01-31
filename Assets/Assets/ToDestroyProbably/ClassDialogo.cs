using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public abstract class ClassDialogo : MonoBehaviour
{
    [SerializeField] private Sprite[] dialogueImages;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject dialogueImage;
    [SerializeField] private int lineIndex;
    [SerializeField] private GameObject exclamacion;
    [SerializeField] private GameObject buttonTalk;
    [SerializeField] private GameObject buttonSi;
    [SerializeField] private GameObject buttonNo;
    [SerializeField] private bool dialogue;

    public bool siyno = false;
    public bool isDialogueActive1 = false;

    // =========================
    // TPFinal - Control de input
    // =========================
    private Movimiento movimiento;

    protected virtual void Start()
    {
        movimiento = FindObjectOfType<Movimiento>();
        DesactivarAll();
    }

    public virtual void Update()
    {
        if (isDialogueActive1)
        {
            dialoguePanel.SetActive(true);
        }
        else
        {
            dialoguePanel.SetActive(false);
        }

        if (dialogue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDialogueActive1 = true;
                dialoguePanel.SetActive(true);
                MostrarDialogo();
                exclamacion.SetActive(false);
                dialogue = false;
            }
        }
        else
        {
            if (!siyno)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    lineIndex++;
                }
            }
        }

        if (lineIndex >= 0 && lineIndex < dialogueImages.Length)
        {
            dialogueImage.GetComponent<Image>().sprite = dialogueImages[lineIndex];
        }
    }

    protected void SiyNo(int linea)
    {
        if (lineIndex == linea)
        {
            buttonSi.SetActive(true);
            buttonNo.SetActive(true);
            siyno = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            buttonTalk.SetActive(true);
            exclamacion.SetActive(true);
            dialogue = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            buttonTalk.SetActive(false);
            exclamacion.SetActive(false);
            dialogue = false;
        }
    }

    public void ActivarButtonTalk()
    {
        isDialogueActive1 = true;
        dialoguePanel.SetActive(true);
        MostrarDialogo();
    }

    private void MostrarDialogo()
    {
        buttonTalk.SetActive(false);
        dialogueImage.GetComponent<Image>().sprite = dialogueImages[lineIndex];
        ActivarModoDialogo();
    }

    private void ActivarModoDialogo()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        if (movimiento != null)
            movimiento.BloquearMovimiento();
    }

    private void DesactivarModoDialogo()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;

        if (movimiento != null)
            movimiento.DesbloquearMovimiento();
    }

    public void DesactivarAll()
    {
        buttonTalk.SetActive(false);
        buttonSi.SetActive(false);
        buttonNo.SetActive(false);
        dialoguePanel.SetActive(false);
        isDialogueActive1 = false;
        siyno = false;

        DesactivarModoDialogo();
    }

    public void ReiniciarDialogo(int linea)
    {
        if (lineIndex != linea)
        {
            lineIndex = linea;
            buttonTalk.SetActive(true);
            siyno = true;
        }
    }

    public virtual void ActivarButtonSi()
    {
        DesactivarAll();
    }

    public virtual void ActivarButtonNo()
    {
        DesactivarAll();
        exclamacion.SetActive(true);
        buttonTalk.SetActive(true);
        dialogue = true;
    }
}

