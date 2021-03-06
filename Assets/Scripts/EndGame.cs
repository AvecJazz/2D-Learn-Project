using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGame : MonoBehaviour
{

    [SerializeField] Text endGameTextPrefab;
    private Text endGameText;

    private void Awake()
    {
        endGameText = Instantiate(endGameTextPrefab);
        endGameText.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    private void Update()
    {
        if (Player.sharedInstance == null) 
        {
            GameOver();
        }
    }
    public void GameOver() 
    {

        Time.timeScale = 0;
        endGameText.text = $"Игра окончена \n Время: {Timer.sharedInstance.displayTime} \n ESC - выход \n R - заново";

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
