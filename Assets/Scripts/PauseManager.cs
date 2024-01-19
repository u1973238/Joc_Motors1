using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenu;

    private bool isPaused = false;

    void Update()
    {
        // Check for user input to toggle pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pause");
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        // Toggle between paused and unpaused states
        if (isPaused)
        {
            PauseMenu.SetActive(true);
            PauseGame();
        }
        else
        {
            PauseMenu.SetActive(false);
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Set time scale to 0 to pause the game
        // You may want to show a pause menu or perform other pause-related actions here
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Set time scale back to 1 to resume the game
        // You may want to hide the pause menu or perform other resume-related actions here
    }
}
