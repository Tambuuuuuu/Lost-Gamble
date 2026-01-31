using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButtom : MonoBehaviour
{
    [SerializeField] private GameObject WinUI;
    
    public void OffWinUI()
    {
        WinUI.SetActive(false);
    }
}
