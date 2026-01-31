using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacer : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
    }
}

