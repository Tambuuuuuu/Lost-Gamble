using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Movimiento : MonoBehaviour
{
    public enum PlayerState { Idle, Walking }

    public struct MovementInput
    {
        public float x;
        public float y;
    }

    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;

    public event Action<PlayerState> OnStateChanged;

    private PlayerState currentState;

    public MovementInput CurrentInput { get; private set; }


    private bool canMove = true;

    public void BloquearMovimiento()
    {
        canMove = false;
        CurrentInput = new MovementInput();
        animator.SetFloat("VelX", 0);
        animator.SetFloat("VelY", 0);
        UpdateState();
    }

    public void DesbloquearMovimiento()
    {
        canMove = true;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    void Update()
    {
        if (!canMove)
            return;

        ReadInput();
        Move();
        UpdateState();
    }

    void ReadInput()
    {
        CurrentInput = new MovementInput
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };

        animator.SetFloat("VelX", CurrentInput.x);
        animator.SetFloat("VelY", CurrentInput.y);
    }

    void Move()
    {
        Vector3 move = transform.right * CurrentInput.x +
                       transform.forward * CurrentInput.y;

        transform.position += move * speed * Time.deltaTime;
    }

    void UpdateState()
    {
        PlayerState newState =
            (CurrentInput.x != 0 || CurrentInput.y != 0)
            ? PlayerState.Walking
            : PlayerState.Idle;

        if (newState != currentState)
        {
            currentState = newState;
            OnStateChanged?.Invoke(currentState);
        }
    }
}
