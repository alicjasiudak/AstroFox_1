using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float timeValue = 90;
    public TextMeshProUGUI timer;
    public delegate void GameOver();
    public static event GameOver gameOver;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            if (gameOver != null) gameOver();
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float miliseconds = timeToDisplay % 1 * 1000;
        timer.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
        if (timeToDisplay <= 15)
        {
            timer.color = Color.red;
        }else
        {
            timer.color = Color.white;
        }
    }

    void OnEnable()
    {
        PlayerController.poweredUp += PowerMaster;
    }

    private void OnDisable()
    {
        PlayerController.poweredUp -= PowerMaster;
    }

    void PowerMaster()
    {
        timeValue += 10;
    }
}
