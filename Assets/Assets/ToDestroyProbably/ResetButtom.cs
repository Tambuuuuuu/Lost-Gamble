using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtom : MonoBehaviour
{
    public void ResetGame()
    {
        EventManager.TriggerEvent(EventsType.StartCardGame);
    }
}
