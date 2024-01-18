using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public int MenuScen = 0;
    public int gameStardScen = 1;

    public Slider VolumeSlider;
    public TextMeshProUGUI TextNumber;

    public AudioMixer mixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //Carragem el volum triat
        float volume = PlayerPrefs.GetFloat("Volume", 1.0f);
        SetVolume(volume);
        SetTextNumber(volume);
        VolumeSlider.value = volume;

        //Carragem la resolució escullida
        int width = PlayerPrefs.GetInt("ScreenWidth", Screen.currentResolution.width);
        int height = PlayerPrefs.GetInt("ScreenHeight", Screen.currentResolution.height);

        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ScreenWidth", resolution.width);
        PlayerPrefs.SetInt("ScreenHeight", resolution.height);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(gameStardScen);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MenuScen);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetTextNumber(float val)
    {
        TextNumber.text = val.ToString();
    }
    public void SetVolume(float volume)
    {
        float res = (volume / 100) * 80 - 80;
        mixer.SetFloat("Volume", res);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}