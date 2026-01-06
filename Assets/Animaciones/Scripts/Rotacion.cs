using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rotacion : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    private Movimiento movimiento;

    void Awake()
    {
        movimiento = GetComponent<Movimiento>();
    }

    void Start()
    {
        camara cam = FindObjectOfType<camara>();

        if (cam != null)
        {
            cam.OnHorizontalLook += RotatePlayer;
        }
        else
        {
            Debug.LogError("Rotacion: No se encontró camara");
        }
    }

    public void SetRotationSpeed(float value)
    {
        rotationSpeed = value;
    }

    void RotatePlayer(float mouseX)
    {
        if (movimiento == null)
            return;

        if (movimiento.CurrentInput.y != 0)
        {
            transform.Rotate(Vector3.up * mouseX * rotationSpeed);
        }
    }
}

