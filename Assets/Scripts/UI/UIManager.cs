using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen = null;
    [SerializeField] private GameObject playScreen = null;
    [SerializeField] private GameObject restartScreen = null;
    [SerializeField] private GameObject settingsScreen = null;

    private IPlayUI _playUI;
    private IRestartUI _restartUI;

    private void Awake()
    {
        _playUI = GetComponent<IPlayUI>();
        _restartUI = GetComponent<IRestartUI>();
    }

    void Update()
    {
        if(!GameManager.gameOver)
        {
            _playUI.UpdateText();
        } else if (GameManager.onDeath)
        {
            RestartGameUI();
        }
    }

    public void StartGameUI()
    {
        startScreen.SetActive(false);
        playScreen.SetActive(true);
        GameManager.StartGame();
    }

    public void RestartGameUI()
    {
        restartScreen.SetActive(true);
        playScreen.SetActive(false);
        _restartUI.SetText();
    }

    public void MainMenuGameUI()
    {
        startScreen.SetActive(true);
        playScreen.SetActive(false);
        restartScreen.SetActive(false);
        settingsScreen.SetActive(false);
        GameManager.ResetGame();
    }

    public void SettingsGameUI()
    {
        startScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void ExitGameUI()
    {
        Application.Quit();
    }

    public void SaveGameUI()
    {
        startScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
}
