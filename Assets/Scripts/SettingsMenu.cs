using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    //Bu script ile oyunun açýlýþ ekranýnda ayarlar butonuna bastýðýmýz zaman karþýmýza çýkan ayarlar menüsünü yöneteceðiz.
    //UI kýsmýndan bir panel üzerinde çalýþtýk

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    public void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution{ width = resolution.width, height = resolution.height}).Distinct().ToArray();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resoluitonIndex)
    {
        Resolution resolution = resolutions[resoluitonIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
