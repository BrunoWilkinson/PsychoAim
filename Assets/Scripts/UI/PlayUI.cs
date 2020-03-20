using UnityEngine;
using System.Collections;
using TMPro;

public class PlayUI : MonoBehaviour, IPlayUI
{
    [SerializeField] private TextMeshProUGUI _waveCountText = null;
    [SerializeField] private TextMeshProUGUI _targetCountText = null;

    public void UpdateText()
    {
        _waveCountText.SetText("Wave: " + GameManager.waveCount);
        _targetCountText.SetText("Targets hit: " + GameManager.targetCount);
    }
}
