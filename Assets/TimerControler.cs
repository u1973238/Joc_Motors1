using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerControler : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float timerTime;
    // Start is called before the first frame update
    void Start()
    {
        TimerText.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        timerTime += Time.deltaTime;

        // Format the time as minutes and seconds
        string minutes = Mathf.Floor(timerTime / 60).ToString("00");
        string seconds = (timerTime % 60).ToString("00");

        // Update the TextMeshProUGUI component
        TimerText.text = $"{minutes}:{seconds}";
    }
}
