using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTarget : MonoBehaviour, IMovementTarget
{
    private GameObject _player;

    void Awake()
    {
        _player = GameObject.Find("Player");
    }

    public void Move()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;

        transform.Translate(lookDirection * Time.deltaTime * GameManager.targetSpeed);
    }
}
