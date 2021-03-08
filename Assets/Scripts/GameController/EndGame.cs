using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGame : MonoBehaviour
{

    [SerializeField] GameObject endGamePanelPrefab;
    private GameObject endGamePanel;
    private Text endGameText;

    private void Awake()
    {
        endGamePanel = Instantiate(endGamePanelPrefab);
        endGamePanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        endGameText = endGamePanel.transform.Find("EndGameText").GetComponent<Text>();
        endGameText.GetComponent<Text>();
    }

    private void Update()
    {
        if (Player.sharedInstance == null || Timer.sharedInstance.time <= 0) 
        {
            GameOver();
        }
    }
    public void GameOver() 
    {

        Time.timeScale = 0;
        endGamePanel.SetActive(true);
        endGameText.text = $"Игра окончена \n Собрано монет: {Score.sharedInstance.score} \n Время: {Timer.sharedInstance.displayTotalTime} \n ESC - выход \n R - заново";

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }

    }

    private static void ReloadGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    private static void ExitGame()
    {
        Application.Quit();
    }
}
