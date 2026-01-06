using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Whisky : Trucos
{
    public GameObject whisky;


    public override void ActivarTruco()
    {
        if (!isOnCooldown)
        {
            if (_ruleta)
            {
                if (whisky.activeInHierarchy == false)
                {
                    whisky.SetActive(true);
                    ruleta = FindAnyObjectByType<Ruleta>();
                    ruleta.trucoWhisky = true;
                    StartCoroutine(Cooldown());

                }
            }
            else if (_dado)
            {
                if (whisky.activeInHierarchy == false)
                {
                    whisky.SetActive(true);
                    dado = FindAnyObjectByType<Combate>();
                    dado.trucoWhisky = true;
                    StartCoroutine(Cooldown());

                }

            }
            else if (_ppt)
            {
                if (whisky.activeInHierarchy == false)
                {
                    whisky.SetActive(true);
                    ppt = FindAnyObjectByType<PPT>();
                    ppt.trucoWhisky = true;
                    StartCoroutine(Cooldown());

                }

            }

        }
    }
}

    


