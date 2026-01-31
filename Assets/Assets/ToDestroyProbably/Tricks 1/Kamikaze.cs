using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Trucos
{
    
    public Animator animation;
    public GameObject kamikaze;
    public override void ActivarTruco()
    {
        if (!isOnCooldown)
        {
            if (_ruleta)
            {

                if (kamikaze.activeInHierarchy == false)
                {
                    kamikaze.SetActive(true);
                    ruleta = FindAnyObjectByType<Ruleta>();
                    ruleta.trucoKamikaze = true;
                    StartCoroutine(Cooldown());

                }
            }


            else if (_dado)
                {
                    if (kamikaze.activeInHierarchy == false)
                    {
                        kamikaze.SetActive(true);
                        kamikaze.SetActive(true);
                        dado = FindAnyObjectByType<Combate>();
                        dado.trucoKamikaze = true;
                        StartCoroutine(Cooldown());
                    }



                }
                else if (_ppt)
                {
                    if (kamikaze.activeInHierarchy == false)
                    {
                        kamikaze.SetActive(true);
                        kamikaze.SetActive(true);
                        ppt = FindAnyObjectByType<PPT>();
                        ppt.trucoKamikaze = true;
                        StartCoroutine(Cooldown());
                    }



                }
            }
        }
    }


