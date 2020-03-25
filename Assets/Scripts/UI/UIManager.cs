using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen = null;
    [SerializeField] private GameObject playScreen = null;
    [SerializeField] private GameObject restartScreen = null;

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
}
