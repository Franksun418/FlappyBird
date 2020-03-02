using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public static int score = 0;
    public Text scoreText;

    public static bool GameStarted;

    // Start is called before the first frame update
    void Start()
    {
        score =0;
        Time.timeScale = 1;

        EventManager.AddListener(EventName.GameOverEvent,GameOver);
        EventManager.AddListener(EventName.GameStartEvent,GameStart);
        EventManager.AddListener(EventName.GameRestartEvent,GameRestart);
        EventManager.AddListener(EventName.AddPointIntEvent,AddPoint);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver(){
        Time.timeScale = 0;
        scoreText.gameObject.SetActive(false);
        MenuManager.GoToMenu(MenuName.GameOverPage);

        if(score>PlayerPrefs.GetInt("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore",score);
        }
        PlayerPrefs.Save();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
        scoreText.gameObject.SetActive(true);
        GameStarted = false;
    }

    public void GameStart(){
        GameStarted = true;
    }

    public void AddPoint(int point)
    {
        score+=point;
    }


}
