using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X2 : Trucos
{
    public GameObject x2;
    public Animator animator;
    public override void ActivarTruco()
    {
        if (!isOnCooldown)
        {
            if (_ruleta)
            {
                if (x2.activeInHierarchy == false)
                {
                    x2.SetActive(true);
                    ruleta = FindAnyObjectByType<Ruleta>();
                    ruleta.trucoX2 = true;
                    StartCoroutine(Cooldown());
                }
            }


            else if (_dado)
            {

                if (x2.activeInHierarchy == false)
                {
                    x2.SetActive(true);
                    // x2.SetActive(true);
                    dado = FindAnyObjectByType<Combate>();
                    dado.trucoX2 = true;
                    StartCoroutine(Cooldown());
                }

            }

            else if (_ppt)
            {
                if (x2.activeInHierarchy == false)
                {
                    x2.SetActive(true);
                    ppt = FindAnyObjectByType<PPT>();
                    ppt.trucoX2 = true;
                    StartCoroutine(Cooldown());
                }

            }

        }
    }
}


