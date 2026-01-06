using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Trucos : MonoBehaviour
{
    protected Combate dado;
    protected Ruleta ruleta;
    protected PPT ppt;
    protected MemoTest memotest;
    public bool _ruleta;
    public bool _dado;
    public bool _ppt;
    public bool _memotest;
    public int cooldownTurns = 0;
    public bool isOnCooldown = false;

    public virtual void ActivarTruco()
    {
        
    }
    protected IEnumerator Cooldown()
    {
        isOnCooldown = true;
        int turnsWaited = 0;
        cooldownTurns = 2;
        while (turnsWaited < cooldownTurns)
        {
            yield return new WaitUntil(() => cooldownTurns == 0);
            turnsWaited++;
            Debug.Log("Item cooldown: " + (cooldownTurns - turnsWaited) + " turns remaining.");
        }
        isOnCooldown = false;
    }
}
