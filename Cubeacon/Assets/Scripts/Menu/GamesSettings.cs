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

    public void AudioVolume(Slider slider)
    {
        am.SetFloat("MasterVolume", slider.value);
    }

    public void MusicVolume(Slider slider)
    {
        am.SetFloat("MusicVolume", slider.value);
    }

    public void SFXVolume(Slider slider)
    {
        am.SetFloat("SFXVolume", slider.value);
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
