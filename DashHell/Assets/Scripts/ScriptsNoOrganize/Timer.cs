﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// timer and score for player gameplay
/// </summary>
public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    private float secondsCount;
    public float score = 0;
    bool stopTime = false;
    void Update()
    {
        if (!stopTime)
        UpdateUI();
    }

    /// <summary>
    /// updates UI every frame
    /// </summary>
    public void UpdateUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = secondsCount.ToString("F2") + "'s";
        scoreText.text = score.ToString();
    }
    

    public void ScoreUp()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }

    /// <summary>
    /// stops in game timer
    /// </summary>
    public void StopTime()
    {
        stopTime = true;
    }
}
