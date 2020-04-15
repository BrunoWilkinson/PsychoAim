using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = true;
    public static bool onDeath = false;
    public static float targetSpeed = 1f;
    public static int waveCount = 0;
    public static int targetCount = 0;

    public static void StartGame()
    {
        gameOver = false;
    }

    public static void GameOver()
    {
        gameOver = true;
        onDeath = true;
    }

    public static void ResetGame()
    {
        waveCount = 0;
        targetSpeed = 1;
        targetCount = 0;
        onDeath = false;
    }
}
