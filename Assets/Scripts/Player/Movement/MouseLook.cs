using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour, IMouseLook
{
    [SerializeField] private float sensitivity = 2f;

    private float _xMin = -90f;
    private float _xMax = 90f;
    private MovementInput _movementInput;
    private Quaternion _playerTargetRot;
    private Quaternion _cameraTargetRot;
    private Transform _cameraTransform;

    public Transform playerTransform;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        _movementInput = GetComponent<MovementInput>();
    }

    private void Start()
    {
        _playerTargetRot = playerTransform.localRotation;
        _cameraTargetRot = _cameraTransform.localRotation;
    }

    public void Move()
    {
        float yRot = _movementInput.AimX() * sensitivity;
        float xRot = _movementInput.AimY() * sensitivity;

        _playerTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        _cameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

        _cameraTargetRot = ClampRotationAroundXAxis(_cameraTargetRot);

        playerTransform.localRotation = _playerTargetRot;
        _cameraTransform.localRotation = _cameraTargetRot;
    }

    public void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, _xMin, _xMax);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

}
