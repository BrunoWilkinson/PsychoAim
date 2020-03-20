using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour, IDestroy
{
    public void All()
    {
        GameObject[] targetsInGame = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targetsInGame)
        {
            Destroy(target);
        }
    }
}
