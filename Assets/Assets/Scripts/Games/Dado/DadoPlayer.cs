using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody))]
public class DadoPlayer : ClassDado
{
    public bool usoTrampa = false;
    //public Barradeatencion barradeatencion;

    protected override void Awake()
    {
        base.Awake();
        ObtenerColliders("playerDice", "1", "2", "3", "CaraFake");
    }
    public override void ActivarTruco()
    {
        CambiarColliders(true);
        ChangeMaterial material = FindObjectOfType<ChangeMaterial>();
        material.cambiar();
    }

    protected override void DesactivarTruco()
    {
        CambiarColliders(false);
        ChangeMaterial material = FindObjectOfType<ChangeMaterial>();
        material.volver();
    }

    public override void LanzarDado()
    {
        base.LanzarDado();
        //sound.PlayFirstSound();
    }
}