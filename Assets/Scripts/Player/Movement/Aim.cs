using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour, IAim
{
    [SerializeField] private float _sensitivity = 100f;
    private float _xRotation = 0f;
    private MovementInput _movementInput;

    public Transform playerTransform;

    private void Awake()
    {
        _movementInput = GetComponent<MovementInput>();
    }

    public void Move()
    {
        float mouseX = _movementInput.AimX() * _sensitivity * Time.deltaTime;
        float mouseY = _movementInput.AimY() * _sensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);


        Camera.main.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }

}
