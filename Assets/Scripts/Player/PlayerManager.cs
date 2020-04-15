using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private IMouseLook _mouseLook;
    private IMovement _movement;
    private IRayProvider _rayProvider;
    private IFireInput _fireInput;


    void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _fireInput = GetComponent<IFireInput>();
        _mouseLook = GetComponent<IMouseLook>();
        _movement = GetComponent<IMovement>();
    }

    void LateUpdate()
    {
        if(!GameManager.gameOver)
        {
            _movement.Gravity();
            _movement.Jump();
            _movement.Run();
            if (_fireInput.CheckFireDown())
            {
                _rayProvider.FireRay("Target");
            }
            if (_movement.OutOfBound())
            {
                GameManager.GameOver();
            }
            _mouseLook.Move();
            _mouseLook.LockCursor();
        } else
        {
            _movement.ResetPosition();
            _mouseLook.UnlockCursor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            GameManager.GameOver();
        }
    }
}
