using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private ISpawn _spawn;
    private IDestroy _destroy;
    private IDifficulty _difficulty;

    private void Awake()
    {
        _spawn = GetComponent<ISpawn>();
        _destroy = GetComponent<IDestroy>();
        _difficulty = GetComponent<IDifficulty>();
    }

    void Update()
    {   
        if (!GameManager.gameOver)
        {
            var targets = GameObject.FindGameObjectsWithTag("Target").Length;
            if (targets == 0)
            {
                GameManager.waveCount++;
                _difficulty.UpSpeed();
                _spawn.All(GameManager.waveCount);
            }
        } else
        {
            _destroy.All();
        }
    }
}

