using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInput : MonoBehaviour, IFireInput
{
    public bool CheckFireDown()
    {
        return Input.GetButtonDown("Fire1");
    }
}
