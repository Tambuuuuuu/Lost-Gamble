using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnemigoDado : ClassDialogo
{
    protected override void Start()
    {
        base.Start();

        if (GameEvent.Instance != null)
        {
            GameEvent.EnterDado += escenadado;
        }
    }

    private void OnDestroy()
    {
        if (GameEvent.Instance != null)
        {
            GameEvent.EnterDado -= escenadado;
        }
    }

    public override void Update()
    {
        base.Update();
        SiyNo(4);
    }

    public override void ActivarButtonNo()
    {
        base.ActivarButtonNo();
        ReiniciarDialogo(4);
    }

    public override void ActivarButtonSi()
    {
        base.ActivarButtonSi();

        if (GameEvent.Instance != null)
        {
            GameEvent.Instance.dado();
        }
    }

    public void escenadado()
    {
        SceneManager.LoadScene(2);
    }
}
