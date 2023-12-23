using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public bool isGameOver = false;
    public int playerScore = 0;
    public Text scoreText;
    public Image cloud;
    public Button menuBtn;
    public GameObject gameOverScreen;

    void Start()
    {
        if (menuBtn != null)
            menuBtn.onClick.AddListener(openMenu);
        else
            Debug.LogError("Play button not assigned.");
    }

    void Update()
    {
        MenuScreen.moveCloud(cloud);
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        ++playerScore;
        scoreText.text = playerScore.ToString();
    }

    private void saveBestScore()
    {
        int savedScore = PlayerPrefs.GetInt("BestScore", 0);
        int score = playerScore > savedScore ? playerScore : savedScore;
        PlayerPrefs.SetInt("BestScore", score);
        PlayerPrefs.Save();
    }

    public void gameOver()
    {
        saveBestScore();
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void openMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
