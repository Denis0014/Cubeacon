using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GamesSettings : MonoBehaviour
{
    Resolution[] rsl;
    List<string> resolutions;
    public TMPro.TMP_Dropdown dropdown;
    bool isFullScreen;
    public AudioMixer am;
    public Toggle tg;

    public void Awake()
    {
        isFullScreen = Screen.fullScreen;
        if (isFullScreen)
        {
            isFullScreen = false;
            tg.isOn = true;
        }
        else
        {
            tg.isOn = false;
        }
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height + " : " + i.refreshRate);
        }
        dropdown.AddOptions(resolutions);
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("Master", sliderValue);
    }

    public void MusicVolume(float sliderValue)
    {
        am.SetFloat("Music", sliderValue);
    }

    public void SFXVolume(float sliderValue)
    {
        am.SetFloat("SFX", sliderValue);
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void Resolution(int r)
    {
        r--;
        if (r == -1)
            return;
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen, rsl[r].refreshRate);
    }
}
