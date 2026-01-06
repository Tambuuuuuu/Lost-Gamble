using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EventManager.TriggerEvent(EventsType.ActiveTrick);
        }
    }
}
