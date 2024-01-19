using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineDetector : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LoseScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Debug.Log("Player");
            WinScreen.SetActive(true);
            Time.timeScale = 0f;
        }

        if(collision.tag == "IA")
        {
            //Debug.Log("IA");
            LoseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
