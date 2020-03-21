using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int waveCount = 0;
    public static bool gameOver = true;
    public static float targetSpeed = 1f;
    public static int targetCount = 0;

    [SerializeField] private GameObject _startScreen = null;
    [SerializeField] private GameObject _playScreen = null;
    [SerializeField] private GameObject _restartScreen = null;

    private IPlayUI _playUI;
    private IRestartUI _restartUI;

    private void Awake()
    {
        _playUI = GetComponent<IPlayUI>();
        _restartUI = GetComponent<IRestartUI>();
    }

    void Update()
    {
        _playUI.UpdateText();
    }

    public void StartGame()
    {
        gameOver = false;
        _startScreen.SetActive(false);
        _playScreen.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GameOver()
    {
        gameOver = true;
        _restartScreen.SetActive(true);
        _playScreen.SetActive(false);
        _restartUI.SetText();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        waveCount = 0;
        targetSpeed = 1;
        targetCount = 0;
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
