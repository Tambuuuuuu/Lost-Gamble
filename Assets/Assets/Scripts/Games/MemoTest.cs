using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*public class MemoTest : Barradeatencion
{
    public enum EstadoTurno
    {
        Esperando,
        TurnoJugador,
        FinCombate
    }

    public EstadoTurno estadoTurno;

    [Header("UI")]
    public GameObject turnoespera;
    public GameObject turnotuyo;

    [Header("Puzzles")]
    [SerializeField] private Sprite bgImage;
    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> botones = new List<Button>();

    private int Aciertos;
    private int Eleccion1Index = -1;
    private int Eleccion2Index = -1;
    private string Eleccion1Puzzle;
    private string Eleccion2Puzzle;

    private bool Eleccion1;
    private bool Eleccion2;

    [Header("Estado")]
    public int puntosEnemigo = 0;
    public bool inGame;
    public bool inventory;
    private bool usoTruco;
    public static bool playerWon = false;

    private bool bloqueandoInput = false;
    private bool trucoRevelando = false;

    private Pintura pintura;
    private Inventario inv;

    protected override void Start()
    {
        base.Start();

        Aciertos = 0;

        GetBotones();
        Listeners();
        AddGamePuzzles();
        Mezclar(gamePuzzles);

        if (inGame)
        {
            inv = FindObjectOfType<Inventario>();
            pintura = FindObjectOfType<Pintura>();

            inv.Memotest = true;
            inv.inGame = true;
            pintura._memotest = true;

            trucoPintura = false;
            StartCoroutine(InicioCombate());
        }
    }

    protected override void Update()
    {
        base.Update();

        inventory = estadoTurno == EstadoTurno.Esperando;

        if (!usoTruco)
            deteccion(inGame);
        else
            Nodeteccion(inGame);
    }

    private IEnumerator InicioCombate()
    {
        while (true)
        {
            if (trucoPintura)
            {
                ActivarTruco();
                usoTruco = false;
            }

            if (Aciertos == gamePuzzles.Count / 2 || puntosEnemigo == 3)
            {
                deteccionTriggered = false;
                pintura._memotest = false;
                StartCoroutine(EndGame());
                break;
            }

            yield return null;
        }
    }

    private IEnumerator EndGame()
    {
        if (Aciertos == gamePuzzles.Count / 2)
        {
            yield return StartCoroutine(SoundVictory());
            GameEvent.Instance?.victory();
            playerWon = true;
        }
        else
        {
            yield return StartCoroutine(SoundLose());
            GameEvent.Instance?.lose();
        }

        SceneManager.LoadScene(1);
    }

    private IEnumerator SoundVictory()
    {
        sound.PlayMusic(sound.victoryMusic);
        yield return new WaitForSeconds(3);
    }

    private IEnumerator SoundLose()
    {
        sound.PlayMusic(sound.defeatMusic);
        yield return new WaitForSeconds(3);
    }

    // BOTONES
    void GetBotones()
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Boton Puzzle");

        foreach (GameObject obj in objetos)
        {
            Button b = obj.GetComponent<Button>();
            botones.Add(b);
            b.image.sprite = bgImage;
            b.image.color = Color.white;
        }
    }

    void AddGamePuzzles()
    {
        int index = 0;
        for (int i = 0; i < botones.Count; i++)
        {
            if (index == botones.Count / 2) index = 0;
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void Listeners()
    {
        foreach (Button boton in botones)
            boton.onClick.AddListener(ElegirPieza);
    }

    // GAMEPLAY
    public void ElegirPieza()
    {
        if (bloqueandoInput || trucoRevelando) return;

        int selectedIndex = int.Parse(
            UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name
        );

        if (Eleccion1 && Eleccion1Index == selectedIndex) return;
        if (botones[selectedIndex].image.color.a == 0f) return;

        if (!Eleccion1)
        {
            Eleccion1 = true;
            Eleccion1Index = selectedIndex;
            Eleccion1Puzzle = gamePuzzles[selectedIndex].name;
            botones[selectedIndex].image.sprite = gamePuzzles[selectedIndex];
        }
        else if (!Eleccion2)
        {
            Eleccion2 = true;
            Eleccion2Index = selectedIndex;
            Eleccion2Puzzle = gamePuzzles[selectedIndex].name;
            botones[selectedIndex].image.sprite = gamePuzzles[selectedIndex];

            bloqueandoInput = true;
            SetBotonesInteractables(false);
            StartCoroutine(LaspiezasCombinan());
            pintura.cooldownTurns--;
        }
    }

    IEnumerator LaspiezasCombinan()
    {
        yield return new WaitForSeconds(1.2f); 

        if (Eleccion1Puzzle == Eleccion2Puzzle)
        {
            botones[Eleccion1Index].interactable = false;
            botones[Eleccion2Index].interactable = false;

            botones[Eleccion1Index].image.color = new Color(1, 1, 1, 0);
            botones[Eleccion2Index].image.color = new Color(1, 1, 1, 0);

            Aciertos++;
        }
        else
        {
            yield return new WaitForSeconds(0.4f);

            botones[Eleccion1Index].image.sprite = bgImage;
            botones[Eleccion2Index].image.sprite = bgImage;

            puntosEnemigo++;
        }

        ResetElecciones();

        yield return new WaitForSeconds(0.2f); 

        bloqueandoInput = false;
        SetBotonesInteractables(true);
    }

    void ResetElecciones()
    {
        Eleccion1 = false;
        Eleccion2 = false;
        Eleccion1Index = -1;
        Eleccion2Index = -1;
        Eleccion1Puzzle = "";
        Eleccion2Puzzle = "";
    }

    void SetBotonesInteractables(bool value)
    {
        foreach (Button b in botones)
        {
            if (b.image.color.a == 0f) continue;
            b.interactable = value;
        }
    }

    // TRUCO PINTURA
    private void ActivarTruco()
    {
        trucoRevelando = true;
        StartCoroutine(RevealTruco());
    }

    IEnumerator RevealTruco()
    {
        bloqueandoInput = true;
        SetBotonesInteractables(false);

        for (int i = 0; i < botones.Count; i++)
        {
            if (botones[i].image.color.a == 0f) continue;
            botones[i].image.sprite = gamePuzzles[i];
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < botones.Count; i++)
        {
            if (botones[i].image.color.a == 0f) continue;
            botones[i].image.sprite = bgImage;
        }

        trucoPintura = false;
        trucoRevelando = false;
        bloqueandoInput = false;
        SetBotonesInteractables(true);
    }

    void Mezclar(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            Sprite temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

}*/






