using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    /**
     * Flag to check if the game is over.
     */
    public bool isGameOver = false;

    /**
     * Player's current score.
     */
    public int playerScore = 0;

    /**
     * UI Text to display the score.
     */
    public Text scoreText;

    /**
     * Cloud image for animation.
     */
    public Image cloud;

    /**
     * Button to open the menu.
     */
    public Button menuBtn;

    /**
     * Game over screen object.
     */
    public GameObject gameOverScreen;

    /**
     * Start is called before the first frame update.
     * Assigns the openMenu function to the menu button's onClick event.
     */
    void Start()
    {
        if (menuBtn != null)
            menuBtn.onClick.AddListener(openMenu);
        else
            Debug.LogError("Play button not assigned.");
    }

    /**
     * Update is called once per frame.
     * Updates cloud movement.
     */
    void Update()
    {
        MenuScreen.moveCloud(cloud);
    }

    /**
     * Increases the player's score.
     */
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        ++playerScore;
        scoreText.text = playerScore.ToString();
    }

    /**
     * Saves the best score.
     */
    private void saveBestScore()
    {
        int savedScore = PlayerPrefs.GetInt("BestScore", 0);
        int score = playerScore > savedScore ? playerScore : savedScore;
        PlayerPrefs.SetInt("BestScore", score);
        PlayerPrefs.Save();
    }

    /**
     * Handles game over logic.
     */
    public void gameOver()
    {
        saveBestScore();
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }

    /**
     * Restarts the game by reloading the current scene.
     */
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /**
     * Opens the menu by loading the Main Menu scene.
     */
    public void openMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
