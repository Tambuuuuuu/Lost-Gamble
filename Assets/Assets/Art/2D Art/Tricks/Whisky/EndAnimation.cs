using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    public GameObject animobject;
    public void FinalizarAnimacion()
    {
        animobject.SetActive(false);
    }
}
