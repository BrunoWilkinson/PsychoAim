using UnityEngine;

public interface IRayProvider
{
    bool CreateRay();
    void FireRay(string tagName);
    RaycastHit GetRayHit();
}