using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager _gameManager;
    private IMouseLook _mouseLook;
    private IMovement _movement;
    private IRayProvider _rayProvider;
    private IFireInput _fireInput;


    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
                _gameManager.GameOver();
            }
            _mouseLook.Move();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            _gameManager.GameOver();
        }
    }
}
