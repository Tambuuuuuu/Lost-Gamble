using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;
/*public class PPT : Barradeatencion
{
    public enum EstadoTurno
    {
        Esperando,
        TurnoJugadorYEnemigo,
        PostRonda,
        FinCombate
    }

    public EstadoTurno estadoTurno;

    public GameObject turnoambos;
    public GameObject turnofinal;
    public GameObject turnoespera;

    public TextMeshProUGUI playerCounterText;
    public TextMeshProUGUI enemyCounterText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI eventText;

    public GameObject buttonPiedra;
    public GameObject buttonPapel;
    public GameObject buttonTijera;

    private Whisky whisky;
    private Pintura pintura;
    private Moneda moneda;
    private Kamikaze kamikaze;
    // private Contrato contrato;

    private Inventario inv;
    private UI_PPT ui;

    private string playerOption;
    private string enemyOption;
    private bool gameOver = false;

    public bool inGame = false;
    public bool inventory = false;
    public bool UsoTruco;

    public int puntosJugador = 0;
    public int puntosEnemigo = 0;

    public static bool playerWon = false;

    private void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    private void LoseReference()
    {
        inv.inGame = false;
        inGame = false;
    }

    protected override void Start()
    {
        base.Start();

        // =========================
        // 🖱️ ACTIVAR MOUSE EN PPT
        // =========================
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        inventory = false;

        inv = FindObjectOfType<Inventario>();
        ui = FindObjectOfType<UI_PPT>();
        whisky = FindObjectOfType<Whisky>();
        moneda = FindObjectOfType<Moneda>();
        pintura = FindObjectOfType<Pintura>();
        kamikaze = FindObjectOfType<Kamikaze>();
        // contrato = FindObjectOfType<Contrato>();

        if (inGame)
        {
            inv.inGame = true;
            inv.Ppt = true;

            trucoMoneda = false;
            trucoPintura = false;
            trucoWhisky = false;

            whisky._ppt = true;
            pintura._ppt = true;
            moneda._ppt = true;
            kamikaze._ppt = true;
            // contrato._ppt = true;

            StartCoroutine(InicioCombate());
        }

        if (GameEvent.Instance != null)
        {
            GameEvent.EnterLose += ChangeScene;
            GameEvent.EnterLose += LoseReference;
            GameEvent.EnterVictory += ChangeScene;
            GameEvent.EnterVictory += LoseReference;
        }
    }

    private void OnDestroy()
    {
        // =========================
        // 🔒 RESTAURAR MOUSE
        // =========================
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (GameEvent.Instance != null)
        {
            GameEvent.EnterLose -= ChangeScene;
            GameEvent.EnterLose -= LoseReference;
            GameEvent.EnterVictory -= ChangeScene;
            GameEvent.EnterVictory -= LoseReference;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (estadoTurno == EstadoTurno.Esperando)
            inventory = true;
        else
            inventory = false;

        if (!UsoTruco)
            deteccion(inGame);
        else
            Nodeteccion(inGame);

        playerCounterText.text = "Victorias del Jugador: " + puntosJugador;
        enemyCounterText.text = "Victorias del Enemigo: " + puntosEnemigo;
    }

    private IEnumerator InicioCombate()
    {
        while (puntosJugador < 3 && puntosEnemigo < 3)
        {
            eventText.text = "";

            yield return StartCoroutine(EsperarTurno());

            if (trucoKamikaze)
            {
                puntosJugador = 2;
                puntosEnemigo = 2;
            }

            yield return StartCoroutine(TurnoJugadorYEnemigo());

            if (trucoMoneda)
            {
                UsoTruco = false;
                puntosJugador++;
                eventText.text = "El enemigo se distrajo con una moneda, no jugó esta ronda";
            }
            else
            {
                CompararOpciones();
            }

            yield return StartCoroutine(PostRonda());
        }

        StartCoroutine(fin());
    }

    private IEnumerator fin()
    {
        if (turnoespera.activeInHierarchy)
            turnoespera.SetActive(false);

        if (turnoambos.activeInHierarchy)
            turnoambos.SetActive(false);

        if (!turnofinal.activeInHierarchy)
            turnofinal.SetActive(true);

        StartCoroutine(EndGame());
        yield return new WaitForSeconds(1);
    }

    private IEnumerator EndGame()
    {
        if (puntosJugador >= 3)
        {
            resultText.text = "¡Has ganado el juego!";
            gameOver = true;

            whisky._ppt = false;
            pintura._ppt = false;
            moneda._ppt = false;

            yield return StartCoroutine(SoundVictory());

            estadoTurno = EstadoTurno.FinCombate;

            if (GameEvent.Instance != null)
                GameEvent.Instance.victory();

            playerWon = true;
        }
        else
        {
            resultText.text = "¡Has perdido el juego!";
            gameOver = true;

            whisky._ppt = false;
            pintura._ppt = false;
            moneda._ppt = false;

            yield return StartCoroutine(SoundLose());

            estadoTurno = EstadoTurno.FinCombate;

            if (GameEvent.Instance != null)
                GameEvent.Instance.lose();
        }
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

    private IEnumerator EsperarTurno()
    {
        turnoespera.SetActive(true);
        turnoambos.SetActive(false);
        turnofinal.SetActive(false);

        estadoTurno = EstadoTurno.Esperando;

        buttonPapel.SetActive(false);
        buttonPiedra.SetActive(false);
        buttonTijera.SetActive(false);

        yield return new WaitForSeconds(2);
    }

    private IEnumerator TurnoJugadorYEnemigo()
    {
        turnoespera.SetActive(false);
        turnoambos.SetActive(true);
        turnofinal.SetActive(false);

        estadoTurno = EstadoTurno.TurnoJugadorYEnemigo;

        buttonPiedra.SetActive(true);
        buttonPapel.SetActive(true);
        buttonTijera.SetActive(true);

        playerOption = null;
        while (playerOption == null)
            yield return null;

        buttonPiedra.SetActive(false);
        buttonPapel.SetActive(false);
        buttonTijera.SetActive(false);

        enemyOption = GetEnemyOption();
    }

    public void PlayerChoice(string option)
    {
        playerOption = option;

        if (!trucoMoneda && !trucoPintura && !trucoWhisky && !trucoKamikaze)
        {
            nocheating = false;
            UsoTruco = true;
        }
    }

    private IEnumerator PostRonda()
    {
        estadoTurno = EstadoTurno.PostRonda;

        yield return new WaitForSeconds(1);

        trucoPintura = false;
        trucoWhisky = false;
        trucoMoneda = false;

        deteccionTriggered = false;

        whisky.cooldownTurns--;
        kamikaze.cooldownTurns--;
        pintura.cooldownTurns--;
        moneda.cooldownTurns--;

        ui.papel.SetActive(false);
        ui.piedra.SetActive(false);
        ui.tijera.SetActive(false);
    }

    private void CompararOpciones()
    {
        if (trucoPintura)
        {
            UsoTruco = false;

            if (enemyOption == "Tijeras")
            {
                playerOption = "Piedra";
                puntosJugador++;
                eventText.text = "¡Cambiaste tu mano sin que se diera cuenta!";
                ui.piedra.SetActive(true);
            }
            else if (enemyOption == "Piedra")
            {
                playerOption = "Papel";
                puntosJugador++;
                eventText.text = "¡Cambiaste tu mano sin que se diera cuenta!";
                ui.papel.SetActive(true);
            }
            else if (enemyOption == "Papel")
            {
                playerOption = "Tijeras";
                puntosJugador++;
                eventText.text = "¡Cambiaste tu mano sin que se diera cuenta!";
                ui.tijera.SetActive(true);
            }
        }
        else
        {
            if (playerOption == enemyOption)
                resultText.text = "Empate";
            else if (
                (playerOption == "Piedra" && enemyOption == "Tijera") ||
                (playerOption == "Papel" && enemyOption == "Piedra") ||
                (playerOption == "Tijera" && enemyOption == "Papel")
            )
            {
                puntosJugador++;
                resultText.text = "Ganaste";
            }
            else
            {
                puntosEnemigo++;
                resultText.text = "Perdiste";
            }
        }
    }

    string GetEnemyOption(string playerOption = "")
    {
        string[] options = { "Piedra", "Papel", "Tijeras" };
        int chances = Random.Range(0, 100);

        if (trucoWhisky)
        {
            UsoTruco = false;

            switch (playerOption)
            {
                case "Piedra":
                    return chances <= 80 ? "Tijeras" : "Papel";
                case "Papel":
                    return chances <= 80 ? "Piedra" : "Tijeras";
                case "Tijeras":
                    return chances <= 80 ? "Papel" : "Piedra";
                default:
                    return options[Random.Range(0, 3)];
            }
        }

        return options[Random.Range(0, 3)];
    }
}*/

