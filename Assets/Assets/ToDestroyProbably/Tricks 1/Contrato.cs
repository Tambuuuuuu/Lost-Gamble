using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contrato : Trucos
{
    public GameObject contrato;
    public Animator animacion;

    public override void ActivarTruco()
    {
        if (!isOnCooldown)
        {
            if (_ruleta)
            {
                if (contrato.activeInHierarchy == false)
                {
                    contrato.SetActive(true);
                    ruleta = FindAnyObjectByType<Ruleta>();
                    ruleta.trucoContrato = true;
                    StartCoroutine(Cooldown());

                }
            }


            else if (_dado)
            {
                if (contrato.activeInHierarchy == false)
                {
                    contrato.SetActive(true);
                    contrato.SetActive(true);
                    dado = FindAnyObjectByType<Combate>();
                    dado.trucoContrato = true;
                    StartCoroutine(Cooldown());
                }




            }
            else if (_ppt)
            {
                if (contrato.activeInHierarchy == false)
                {
                    contrato.SetActive(true);
                    //contrato.SetActive(true);
                    ppt = FindAnyObjectByType<PPT>();
                    ppt.trucoPintura = true;
                    StartCoroutine(Cooldown());
                }



            }
            else if (_ruleta)
            {
                if (contrato.activeInHierarchy == false)
                {
                    contrato.SetActive(true);
                    contrato.SetActive(true);
                    ruleta = FindAnyObjectByType<Ruleta>();
                    ruleta.trucoContrato = true;
                    StartCoroutine(Cooldown());
                }



            }
        }
    }
}


