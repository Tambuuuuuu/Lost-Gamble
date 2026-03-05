using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class AlphaHitTestEnabler : MonoBehaviour
{
    void Awake()
    {
        Image img = GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = 0.1f;
    }
}
