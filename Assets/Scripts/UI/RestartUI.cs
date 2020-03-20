using UnityEngine;
using System.Collections;
using TMPro;

public class RestartUI : MonoBehaviour, IRestartUI
{
    [SerializeField] private TextMeshProUGUI _waveTotalText = null;
    [SerializeField] private TextMeshProUGUI _targetTotalText = null;

    public void SetText()
    {
        _waveTotalText.SetText("Wave: " + GameManager.waveCount);
        _targetTotalText.SetText("Targets: " + GameManager.targetCount);
    }
}
