using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/*public enum ColorType
{
    None,
    Rojo,
    Negro,
    Verde,
    
}

public enum EstadoTurno
{
    Esperando,
    TurnoJugador,
    TurnoEnemigo,
    FinCombate
}

public enum GameState
{
    Normal,
    TrucoActivado
}

public class Ruleta : Barradeatencion
{
    [Header("UI")]
    [SerializeField] private Button[] botonesColores;
    
    [Header("Inventario")]
    public bool inGame = true;
    public bool inventory = true;

    [Header("Ruletas")]
    public GameObject ruletaNormal;
    public GameObject ruletaRoja;
    public GameObject ruletaNegra;
    public GameObject ruletaVerde;

    [Header("Animators")]
    public Animator animatorNormal;
    public Animator animatorRoja;
    public Animator animatorNegra;
    public Animator animatorVerde;

    [Header("Turnos UI")]
    public GameObject turnoespera;
    public GameObject turnotuyo;
    public GameObject turnoenemigo;

    [Header("Estado")]
    public ColorType trucoColor = ColorType.None;
    public GameState gameState = GameState.Normal;
    public EstadoTurno estadoTurno;

    public int apostado;
    public int apostadoEnemigo;
    public int puntosJugador;
    public int puntosEnemigo;
    public int ganador;

    private bool usoTruco;
    public static bool playerWon;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(InicioCombate());
    }

    private IEnumerator InicioCombate()
    {
        while (puntosJugador < 3 && puntosEnemigo < 3)
        {
            yield return StartCoroutine(EsperarTurno());
            yield return StartCoroutine(TurnoJugador());
            yield return StartCoroutine(TurnoEnemigo());
            yield return StartCoroutine(SpinRoulette());
            ActualizarRondas();
        }

        StartCoroutine(EndGame());
    }

    private IEnumerator EsperarTurno()
    {
        estadoTurno = EstadoTurno.Esperando;

        turnoespera.SetActive(true);
        turnotuyo.SetActive(false);
        turnoenemigo.SetActive(false);

        foreach (Button b in botonesColores)
            b.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);
    }

    private IEnumerator TurnoJugador()
    {
        estadoTurno = EstadoTurno.TurnoJugador;

        turnoespera.SetActive(false);
        turnotuyo.SetActive(true);

        foreach (Button b in botonesColores)
            b.gameObject.SetActive(true);

        yield return new WaitUntil(() => apostado != 0);

        foreach (Button b in botonesColores)
            b.gameObject.SetActive(false);
    }

    private IEnumerator TurnoEnemigo()
    {
        estadoTurno = EstadoTurno.TurnoEnemigo;

        turnotuyo.SetActive(false);
        turnoenemigo.SetActive(true);

        yield return new WaitForSeconds(1f);

        List<ColorType> opciones = new List<ColorType>
        {
            ColorType.Rojo,
            ColorType.Negro,
            ColorType.Verde
        };

        opciones.Remove((ColorType)apostado);
        apostadoEnemigo = (int)opciones[Random.Range(0, opciones.Count)];
    }

    // =======================
    // 🎰 GIRO DE RULETA (FIX)
    // =======================
    private IEnumerator SpinRoulette()
    {
        Animator anim = ObtenerAnimatorActivo();

        if (anim == null)
        {
            Debug.LogError("No hay Animator activo");
            yield break;
        }

        anim.Play("Giro");
        yield return new WaitForSeconds(3f);

        yield return StartCoroutine(DetermineWinner());
    }

    private Animator ObtenerAnimatorActivo()
    {
        switch (trucoColor)
        {
            case ColorType.Rojo:
                return animatorRoja;
            case ColorType.Negro:
                return animatorNegra;
            case ColorType.Verde:
                return animatorVerde;
            default:
                return animatorNormal;
        }
    }

    private IEnumerator DetermineWinner()
    {
        int numero = Random.Range(0, 37);
        ganador = numero;

        ColorType colorGanador = DetermineWinningColor(numero);

        if (apostado == (int)colorGanador)
            puntosJugador++;
        else if (apostadoEnemigo == (int)colorGanador)
            puntosEnemigo++;

        yield return new WaitForSeconds(1f);
    }

    private ColorType DetermineWinningColor(int numero)
    {
        if (numero == 0) return ColorType.Verde;
        if (numero % 2 == 0) return ColorType.Negro;
        return ColorType.Rojo;
    }

    private void ActualizarRondas()
    {
        apostado = 0;
        apostadoEnemigo = 0;
        trucoColor = ColorType.None;
        gameState = GameState.Normal;
    }

    private IEnumerator EndGame()
    {
        if (puntosJugador >= 3)
            playerWon = true;

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    // =======================
    // 🎮 BOTONES
    // =======================
    public void OnRojoButtonClick() => apostado = (int)ColorType.Rojo;
    public void OnNegroButtonClick() => apostado = (int)ColorType.Negro;
    public void OnVerdeButtonClick() => apostado = (int)ColorType.Verde;
}*/

