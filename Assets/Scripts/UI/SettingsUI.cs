using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer = null;
    [SerializeField] private TMP_Dropdown qualityDropdown = null;
    [SerializeField] private TMP_Dropdown resolutionsDropdown = null;
    [SerializeField] private TMP_InputField sensInput = null;
    [SerializeField] private GameObject player = null;

    private Resolution[] _resolutions;

    private void Start()
    {
        GetResolutions();
        GetSensitivity();
    }

    private void GetSensitivity()
    {
        sensInput.text = player.GetComponent<MouseLook>().sensitivity.ToString();
    }

    private void GetResolutions()
    {
        _resolutions = Screen.resolutions.Where(res => res.refreshRate == 60 || res.refreshRate == 144).ToArray();
        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResIndex = 0;

        for (int i = 0; i < _resolutions.Length; i++)
        {
            Resolution res = _resolutions[i];
            Resolution currentRes = Screen.currentResolution;
            string option = res.width + " x " + res.height + " - " + res.refreshRate + "Hz";
            options.Add(option);
            if(res.width == currentRes.width && res.height == currentRes.height)
            {
                currentResIndex = i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int index)
    {
        qualityDropdown.value = index;
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = _resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
