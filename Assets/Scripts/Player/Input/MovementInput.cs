using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour, IMovementInput
{
    public float MovementX()
    {
        return Input.GetAxis("Horizontal");
    }

    public float MovementY()
    {
        return Input.GetAxis("Vertical");
    }

    public float AimX()
    {
        return Input.GetAxis("Mouse X");
    }

    public float AimY()
    {
        return Input.GetAxis("Mouse Y");
    }

    public bool Jump()
    {
        return Input.GetButton("Jump");
    }
}
