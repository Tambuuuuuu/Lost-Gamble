using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
public class Combate : Barradeatencion
{
    public enum EstadoTurno
    {
        Esperando,
        TurnoEnemigo,
        TurnoJugador,
        FinCombate
    }

    public EstadoTurno estadoTurno;
    public GameObject turnoespera;
    public GameObject turnotuyo;
    public GameObject turnoenemigo;
    private DadoPlayer dadoPlayerJugador;
    private DadoEnemigo dadoEnemigo;
    private Whisky whisky;
    private Pintura pintura;
    private X2 x2;
    private Contrato contrato;
    private Kamikaze kamikaze;
    private Moneda moneda;
    private Inventario inv;
    public Animator ladydados1;

    public int puntosJugador = 0;
    public int puntosEnemigo = 0;
    public bool inGame = false;
    public bool inventory;
    public static bool playerWon = false;
    private bool usoTruco;
    public bool tirootravez;
    
    protected override void Start()
    {
        base.Start();
        inv = FindObjectOfType<Inventario>();
        inventory = false;
        whisky = FindObjectOfType<Whisky>();
        moneda = FindObjectOfType<Moneda>();
        pintura = FindObjectOfType<Pintura>();
        contrato  = FindObjectOfType<Contrato>();
        x2 = FindObjectOfType<X2>();
        kamikaze = FindObjectOfType<Kamikaze>();
        if (inGame)
        {
            dadoPlayerJugador = GameObject.FindWithTag("DadoJugador").GetComponent<DadoPlayer>();
            dadoEnemigo = GameObject.FindWithTag("DadoEnemigo").GetComponent<DadoEnemigo>();
            StartCoroutine(InicioCombate());
            inv.dados = true;
            inv.inGame = true;
            whisky._dado = true;
            pintura._dado = true;
            moneda._dado = true;
            x2._dado = true;
            contrato._dado = true;
            kamikaze._dado = true;
            trucoMoneda = false;
            trucoPintura = false;
            trucoWhisky = false;
            trucoKamikaze = false;
            trucoContrato = false;
            trucoX2 = false;
            usoTruco = false;
        }
        if (GameEvent.Instance != null)
        {
            print("cosaEvent");
            GameEvent.EnterLose += ChangeScene;
            GameEvent.EnterLose += LoseReference;
            GameEvent.EnterVictory += ChangeScene;
            GameEvent.EnterVictory += LoseReference;
        }
    }

    protected override void Update()
    {
        base.Update();
        if (estadoTurno == EstadoTurno.Esperando)
        {
            inventory = true;
        }
        else
        {
            inventory = false;
        }
        if (!usoTruco)
        {
            
            deteccion(inGame);
        }
        else
        {
            Nodeteccion(inGame);
        }
    }

    private IEnumerator InicioCombate()
    {
        while (puntosJugador < 3 && puntosEnemigo < 3)
        {
            yield return StartCoroutine(EsperarTurno());
            yield return StartCoroutine(TurnoJugador());
            if (trucoMoneda)
            {
                puntosJugador++;
            }
            else
            {
                yield return StartCoroutine(EsperarTurnoEnemigo());
                ladydados1.SetTrigger("LanzarDados");
                dadoEnemigo.LanzarDado();
                
                

                yield return StartCoroutine(TurnoEnemigoFinalizado());
                ladydados1.ResetTrigger("LanzarDados");
                CompararDados();
                ActualizarRondas();
            }
            
            dadoPlayerJugador.ReiniciarDado();
            dadoEnemigo.ReiniciarDado();
            trucoMoneda = false;
            trucoPintura = false;
            trucoWhisky = false;
            deteccionTriggered = false;
        }
        Debug.Log("Fin del combate.");
        whisky._dado = false;
        StartCoroutine(EndGame());
    }

    private void OnDestroy()
    {
        if (GameEvent.Instance != null)
        {
            print("cosaEvent2");
            GameEvent.EnterLose -= ChangeScene;
            GameEvent.EnterLose -= LoseReference;
            GameEvent.EnterVictory -= ChangeScene;
            GameEvent.EnterVictory -= LoseReference;
        }
    }
    private IEnumerator EndGame()
    {

        if (puntosJugador >= 3)
        {
            yield return StartCoroutine(SoundVictory());
            if (GameEvent.Instance != null)
            {
                GameEvent.Instance.lose();
                
            }
            playerWon = true;

        }
        else if (puntosEnemigo >= 3)
        {
            yield return StartCoroutine(SoundLose());
            if (GameEvent.Instance != null)
            {
                GameEvent.Instance.victory();
            }
        }
    }
    
    private void ChangeScene()
    {
        SceneManager.LoadScene(1);
        
    }
    private void LoseReference()
    {
        Inventario inv = FindObjectOfType<Inventario>();
        inv.inGame = false;
        inGame = false;
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
        if(turnoespera.activeInHierarchy == false)
        {
            turnoespera.SetActive(true);
        }

        if (turnotuyo.activeInHierarchy == true)
        {
            turnotuyo.SetActive(false);
        }

        if (turnoenemigo.activeInHierarchy == true)
        {
            turnoenemigo.SetActive(false);
        }
        estadoTurno = EstadoTurno.Esperando;
        yield return new WaitForSeconds(3);
        
        if (trucoWhisky)
        {
            dadoPlayerJugador.ActivarTruco();
            
            
            usoTruco = false;
        }
        if (trucoPintura)
        {
            dadoEnemigo.ActivarTruco();
            
            
            usoTruco = false;
        }
        if (trucoMoneda)
        {
            usoTruco = false;
        }
        
        if (trucoKamikaze)
        {
            puntosEnemigo += 2;
            puntosJugador += 2;
            usoTruco = false;
        }
       
        if (trucoContrato)
        {
            usoTruco = false;
        }
       

    }
    private IEnumerator EsperarTurnoEnemigo()
    {
        if (turnoespera.activeInHierarchy == true)
        {
            turnoespera.SetActive(false);
        }

        if (turnotuyo.activeInHierarchy == true)
        {
            turnotuyo.SetActive(false);
        }

        if (turnoenemigo.activeInHierarchy == false)
        {
            turnoenemigo.SetActive(true);
        }
       
        estadoTurno = EstadoTurno.TurnoEnemigo;
            yield return new WaitForSeconds(1);
        

    }
    private IEnumerator TurnoJugador()
    {
        if (turnoespera.activeInHierarchy == true)
        {
            turnoespera.SetActive(false);
        }
        if (turnotuyo.activeInHierarchy == false)
        {
            turnotuyo.SetActive(true);
        }
        if (turnoenemigo.activeInHierarchy == true)
        {
            turnoenemigo.SetActive(false);
        }
        if (!trucoMoneda && !trucoPintura && !trucoWhisky)
        {
            nocheating = false;
            
            usoTruco = true;
        }
       
        
        estadoTurno = EstadoTurno.TurnoJugador;
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        dadoPlayerJugador.LanzarDado();
        while (dadoPlayerJugador.lanzando)
        {
            yield return null;
        }
    }

    private IEnumerator TurnoEnemigoFinalizado()
    {
        if (trucoX2)
        {
            estadoTurno = EstadoTurno.TurnoEnemigo;
            usoTruco = false;
            tirootravez = true;
            if (tirootravez)
            {
                while (!Input.GetMouseButtonDown(0))
                {
                    yield return null;
                }
                
                dadoPlayerJugador.LanzarDado();
                while (dadoPlayerJugador.lanzando)
                {
                    yield return null;
                }
            }
        }
        while (dadoEnemigo.lanzando)
        {
            yield return null;
        }
    }


    private void CompararDados()
    {
        int resultadoJugador = dadoPlayerJugador.dicefacenum;
        int resultadoEnemigo = dadoEnemigo.dicefacenum;

        if (resultadoJugador > resultadoEnemigo)
        {
            if (trucoContrato)
            {
                
                puntosJugador += 2;
                usoTruco = false;
            }
            else
            {
                puntosJugador++;
                usoTruco = false;
            }
        }
        else if (resultadoJugador < resultadoEnemigo)
        {
            if (trucoContrato)
            {
                puntosEnemigo += 2;
            }
            else
            {

                puntosEnemigo++;
            }
        }
    }


    private void ActualizarRondas()
    {
        whisky.cooldownTurns--;
        pintura.cooldownTurns--;
        moneda.cooldownTurns--;
        x2.cooldownTurns--;
        contrato.cooldownTurns--;
        kamikaze.cooldownTurns--;
    }
}
