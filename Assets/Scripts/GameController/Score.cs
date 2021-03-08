using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score sharedInstance;

    [SerializeField] GameObject scorePanelPrefab;

    [HideInInspector]
    public int score;

    private GameObject scorePanel;
    private Text textScore;
 
    private void Awake()
    {
        sharedInstance = this;
        scorePanel = Instantiate(scorePanelPrefab);
        scorePanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        textScore = scorePanel.transform.Find("ScoreText").GetComponent<Text>();
        textScore.GetComponent<Text>();
    }

    private void Start()
    {
        textScore.text = $": {score}";
    }

    public void AddScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        textScore.text = $": {score}";
    }

}
