using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 _moveAxis; //control
    public CameraController camaracontrol;


    [SerializeField] private CharacterController _player;//control
    [SerializeField] private float _moveSpeed; //movement
    [SerializeField] private float _gravity;//gravedad
    [SerializeField] private float _fallVelocity;//gravedad
    [SerializeField] private float _jumpforce; //control

    Action FuncionesDeSalto;

    void Awake()
    {
        _player = GetComponent<CharacterController>();//control
        FuncionesDeSalto = SetGravity;
        FuncionesDeSalto += SetJump;
        _moveSpeed = 10f;//movement
        _gravity = 9.81f;//gravity
        _jumpforce = 6.5f;
    }

    private void Update()
    {
        _moveAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));//control
        if (_moveAxis.magnitude > 1) _moveAxis = _moveAxis.normalized * _moveSpeed;
        else _moveAxis = _moveAxis * _moveSpeed;

        FuncionesDeSalto();
        _player.Move(camaracontrol._moveDir * Time.deltaTime);

    }

    private void SetGravity()
    {
        if (_player.isGrounded)
        {
            _fallVelocity = -_gravity * Time.deltaTime;
        }
        else
        {
            _fallVelocity -= _gravity * Time.deltaTime;
        }
        camaracontrol._moveDir.y = _fallVelocity;
    }

    private void SetJump()
    {
        if (_player.isGrounded && Input.GetKey(KeyCode.Space))
        {
            _fallVelocity = _jumpforce;
            camaracontrol._moveDir.y = _fallVelocity;
        }
    }
  
   
}
