using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    private float secondsCount;
    public float score = 0;
    void Update()
    {
        UpdateUI();
    }
    //call this on update
    public void UpdateUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = secondsCount + "s";
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
}
