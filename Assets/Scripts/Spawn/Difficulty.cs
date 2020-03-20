using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour, IDifficulty
{
    [SerializeField] private float upDifficulty = 1f;

    public void UpSpeed()
    {
        if (GameManager.waveCount % 5 == 0)
        {
            GameManager.targetSpeed += upDifficulty;
        }
    }
}
