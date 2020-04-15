using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IMovement
{
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _gravity = 20f;
    [SerializeField] private float _outOfBound = -5f;

    private CharacterController _controller;
    private MovementInput _movementInput;
    private Vector3 _playerMovement = new Vector3();

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _movementInput = GetComponent<MovementInput>();
    }

    public void Run()
    {
        if (_controller.isGrounded)
        {
            float x = _movementInput.MovementX();
            float z = _movementInput.MovementY();
            _playerMovement = transform.right * x + transform.forward * z;

            _controller.Move(_playerMovement * _speed * Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (_controller.isGrounded && _movementInput.Jump())
        {
            _playerMovement.y += _jumpHeight;
            _controller.Move(_playerMovement * Time.deltaTime);
        }
    }

    public void Gravity()
    {
        _playerMovement.y -= _gravity * Time.deltaTime;
        _controller.Move(_playerMovement * Time.deltaTime);
    }

    public bool OutOfBound()
    {
        return transform.position.y < _outOfBound;
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, 1.16f, 0);
    }
}
