using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class camara : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float sensitivity = 150f;
    [SerializeField] private float maxVerticalAngle = 70f;

    private float xRotation;

    public event Action<float> OnHorizontalLook;

    public float Sensitivity
    {
        get => sensitivity;
        set => sensitivity = Mathf.Clamp(value, 50f, 300f);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxVerticalAngle, maxVerticalAngle);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        OnHorizontalLook?.Invoke(mouseX);
    }
}
