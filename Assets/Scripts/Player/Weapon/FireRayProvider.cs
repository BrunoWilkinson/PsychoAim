using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRayProvider : MonoBehaviour, IRayProvider
{
    private RaycastHit _hitProvider;
    private AudioSource _hitAudio;

    void Start()
    {
        _hitAudio = gameObject.GetComponent<AudioSource>();
    }

    public bool CreateRay()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out _hitProvider);
    }

    public RaycastHit GetRayHit()
    {
        return _hitProvider;
    }

    public void FireRay(string tagName)
    {
        if (CreateRay())
        {
            if (_hitProvider.transform.CompareTag(tagName))
            {
                GameManager.targetCount++;
                Destroy(_hitProvider.transform.gameObject);
                _hitAudio.Play();
            }
        }
    }
}
