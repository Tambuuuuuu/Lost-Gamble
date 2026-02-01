using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimacionCorrer : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Movimiento movement;
    [SerializeField] private Rotacion rotation;

    [Header("Velocidades")]
    [SerializeField] public float runSpeed = 7f;
    [SerializeField] public float rotationSpeed = 100f;

    [Header("Estados")]
    public bool ruleta;
    public bool Dado;
    public bool Memo;
    public bool Ppt;

    void Awake()
    {
        movement = GetComponent<Movimiento>();
        rotation = GetComponent<Rotacion>();

        if (movement == null)
        {
            Debug.LogError("AnimacionCorrer: Falta el componente Movimiento");
            return;
        }

        if (rotation == null)
        {
            Debug.LogError("AnimacionCorrer: Falta el componente Rotacion");
            return;
        }

        movement.SetSpeed(runSpeed);
        rotation.SetRotationSpeed(rotationSpeed);
    }


    void Update()
    {
        // Combates
        //if (Combate.playerWon) Dado = true;
        //if (PPT.playerWon) Ppt = true;
        //if (Ruleta.playerWon) ruleta = true;
        //if (MemoTest.playerWon) Memo = true;

        if (Ppt && Dado && Memo)
        {
            SceneManager.LoadScene(7);
        }
    }
}
