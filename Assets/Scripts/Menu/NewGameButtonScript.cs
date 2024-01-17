using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButtonScript : MonoBehaviour
{
    public int gameStardScen = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(gameStardScen);
    }
}
