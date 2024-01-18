using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    public int MenuScen = 0;
    public int gameStardScen = 1;

    public TextMeshProUGUI TextNumber;

    public AudioMixer mixer;
    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;
    private void Start()
    {
        SetVolume(75);
        SetTextNumber(75);

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
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
