using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer sharedInstance;

    [SerializeField] Text textTimerPrefab;

    [HideInInspector]
    public string displayTime;

    private float minutes;
    private float seconds;
    

    private float timer;
    private Text textTimer;

    private void Awake()

    {
        sharedInstance = this;
        textTimer = Instantiate(textTimerPrefab);
        textTimer.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        displayTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        textTimer.text = displayTime;
    }
}
