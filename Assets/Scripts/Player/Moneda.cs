using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moneda : Trucos
{
    public GameObject moneda;
    public Animator animacion;
    public override void ActivarTruco()
    {
        if (!isOnCooldown)
        {
            if (_ruleta)
            {
                if (moneda.activeInHierarchy == false)
                {
                    moneda.SetActive(true);
                    ruleta = FindAnyObjectByType<Ruleta>();
                    ruleta.trucoMoneda = true;
                    StartCoroutine(Cooldown());

                }
            }


            else if (_dado)
            {
                if (moneda.activeInHierarchy == false)
                {
                    moneda.SetActive(true);
                    dado = FindAnyObjectByType<Combate>();
                    dado.trucoMoneda = true;
                    StartCoroutine(Cooldown());
                }
            }
            else if (_ppt)
            {
                if (moneda.activeInHierarchy == false)
                {
                    moneda.SetActive(true);
                    print("Se activo el truco");
                    ppt = FindAnyObjectByType<PPT>();
                    ppt.trucoMoneda = true;
                    StartCoroutine(Cooldown());
                }

            }
        }
    }
}

