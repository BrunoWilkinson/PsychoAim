using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTarget : MonoBehaviour, IMovementTarget
{
    private GameObject _player;
    private Rigidbody _targetRB;

    void Awake()
    {
        _player = GameObject.Find("Player");
    }

    void Start()
    {
        _targetRB = gameObject.GetComponent<Rigidbody>();
    }

    public void Move()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);

        transform.rotation = lookRotation;
        _targetRB.AddForce(lookDirection * Time.deltaTime * GameManager.targetSpeed, ForceMode.Impulse);
    }
}
