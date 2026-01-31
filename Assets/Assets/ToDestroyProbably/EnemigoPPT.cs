using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnemigoPPT : ClassDialogo
{
    protected override void Start()
    {
        base.Start();

        if (GameEvent.Instance != null)
        {
            GameEvent.EnterPPT += escenappt;
        }
    }

    private void OnDestroy()
    {
        if (GameEvent.Instance != null)
        {
            GameEvent.EnterPPT -= escenappt;
        }
    }

    public override void Update()
    {
        base.Update();
        SiyNo(9);
    }

    public override void ActivarButtonNo()
    {
        base.ActivarButtonNo();
        ReiniciarDialogo(9);
    }

    public override void ActivarButtonSi()
    {
        base.ActivarButtonSi();

        if (GameEvent.Instance != null)
        {
            GameEvent.Instance.ppt();
        }
    }

    public void escenappt()
    {
        SceneManager.LoadScene(3);
    }
}

