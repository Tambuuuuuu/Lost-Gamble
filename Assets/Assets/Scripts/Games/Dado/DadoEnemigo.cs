using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class DadoEnemigo : ClassDado
{

    private void Awake()
    {
        base.Awake();
        ObtenerColliders("enemyDice", "6", "4", "5", "EnemyFake");
    }
    public override void ReiniciarDado()
    {
        lanzando = false;
        body.isKinematic = true;
        transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        transform.position = new Vector3(10.308f, 4.1f, -1.17f);
        lanzando = false;
        dicefacenum = 0;
        DesactivarTruco();
    }
    public override void LanzarDado()
    {
        base.LanzarDado();
        sound.PlaySecondSound();
    }
}
