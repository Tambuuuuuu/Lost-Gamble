using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pintura : Trucos
{
    public GameObject pintura;

    public override void ActivarTruco()
    {
        if (isOnCooldown) return;

        if (_memotest)
        {
            if (!pintura.activeInHierarchy)
            {
                pintura.SetActive(true);
                MemoTest memo = FindAnyObjectByType<MemoTest>();
                memo.trucoPintura = true;
                StartCoroutine(Cooldown());
            }
        }
        else if (_ruleta)
        {
            pintura.SetActive(true);
            FindAnyObjectByType<Ruleta>().trucoPintura = true;
            StartCoroutine(Cooldown());
        }
        else if (_dado)
        {
            pintura.SetActive(true);
            FindAnyObjectByType<Combate>().trucoPintura = true;
            StartCoroutine(Cooldown());
        }
        else if (_ppt)
        {
            pintura.SetActive(true);
            FindAnyObjectByType<PPT>().trucoPintura = true;
            StartCoroutine(Cooldown());
        }
    }
}
