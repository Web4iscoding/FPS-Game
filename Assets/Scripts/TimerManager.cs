using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{

    private float time = 0.0f;
    public TextMeshProUGUI timerUI;

    // handling logics and calculations of timer
    private void Update()
    {
        time += Time.deltaTime;
        time.ToString("F1");
        timerUI.text = $"{time}";

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    
}
