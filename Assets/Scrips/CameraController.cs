using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement playtest;
    public Vector3 _moveDir;
    private Vector3 _camForward;
    private Vector3 _camRight;
    public Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        cameraDirection();
        _moveDir = playtest._moveAxis.x * _camRight + playtest._moveAxis.z * _camForward;
        transform.LookAt(transform.position + _moveDir);

    }

    private void cameraDirection()
    {
        _camForward = _camera.transform.forward.normalized;
        _camRight = _camera.transform.right.normalized;

        _camForward.y = 0;
        _camRight.y = 0;
    }
}


