using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour
{
    private Rigidbody _targetRb;
    private IMovementTarget _movementTarget;

    void Awake()
    {
        _targetRb = GetComponent<Rigidbody>();
        _targetRb.velocity = new Vector3(0, 0, 0);
        _movementTarget = GetComponent<IMovementTarget>();
    }

    void Update()
    {
        _movementTarget.Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}
