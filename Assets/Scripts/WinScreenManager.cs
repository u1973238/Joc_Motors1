using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public int MenuScen = 0;
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuScen);
    }
    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        Time.timeScale = 1f;

        // Check if there is a next scene in the build index
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Handle the case where there is no next scene
            Debug.LogWarning("No next scene available. Game completed?");
            SceneManager.LoadScene(0);
        }
    }
}
