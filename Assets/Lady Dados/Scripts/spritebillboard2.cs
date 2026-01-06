using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2 - Ivan De Luca
public class spritebillboard2 : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;
    private void LateUpdate()
    {
        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
