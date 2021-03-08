using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer sharedInstance;

    [SerializeField] GameObject timerPanelPrefab;

    [HideInInspector]
    public string displayTotalTime;
    public float time;

    private float minutes;
    private float seconds;
    private string displayTime;

    private float totalTime;
    private float totalTimeMinutes;
    private float totalTimeSeconds;

    private GameObject timerPanel;
    private Text textTimer;

    private void Awake()

    {
        sharedInstance = this;
        timerPanel = Instantiate(timerPanelPrefab);
        timerPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        textTimer = timerPanel.transform.Find("TimerText").GetComponent<Text>();
        textTimer.GetComponent<Text>();
    }

    void Update()
    {
        CountTimeToEndGame();
        CountTotalTimeInTheGame();
    }

    private void CountTimeToEndGame() 
    {
        time -= Time.deltaTime;
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        displayTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (time >= 0)
        {
            textTimer.text = displayTime;
        }
    }

    private void CountTotalTimeInTheGame() 
    {
        totalTime += Time.deltaTime;
        totalTimeMinutes = Mathf.FloorToInt(totalTime / 60);
        totalTimeSeconds = Mathf.FloorToInt(totalTime % 60);
        displayTotalTime = string.Format("{0:00}:{1:00}", totalTimeMinutes, totalTimeSeconds);
    }
}
