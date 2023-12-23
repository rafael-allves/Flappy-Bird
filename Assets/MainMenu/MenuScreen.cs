using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    /**
     * Images for the top and bottom clouds in the menu screen.
     */
    public Image cloudTop, cloudBottom;

    /**
     * Buttons for starting the game and opening the about page.
     */
    public Button playBtn, aboutBtn;

    /**
     * UI Text to display the best score.
     */
    public Text bestScore;

    /**
     * Speed at which clouds move.
     */
    [SerializeField] private static float cloudSpeed = 100f;

    /**
     * Reset position for the clouds to loop their movement.
     */
    private const float ResetPosition = 1345f;

    /**
     * Loads the best score from PlayerPrefs.
     */
    private int loadBestScore() { return PlayerPrefs.GetInt("BestScore", 0); }
    
    /**
     * Start is called before the first frame update.
     * Initializes the menu screen, sets up button listeners, and displays the best score.
     */
    void Start()
    {
        bestScore.text = "Best Score: " + loadBestScore().ToString();

        if (cloudTop == null || cloudBottom == null)
            Debug.LogError("Cloud objects not found. Make sure your tags are set correctly.");

        Debug.Log("MenuScreen started. Clouds initialized." + cloudTop.tag + cloudBottom.tag);

        if (playBtn != null)
            playBtn.onClick.AddListener(startGame);
        else
            Debug.LogError("Play button not assigned.");

        if (aboutBtn != null)
            aboutBtn.onClick.AddListener(OpenAboutPage);
        else
            Debug.LogError("About button not assigned.");
    }

    /**
     * Update is called once per frame.
     * Handles the movement of clouds in the background.
     */
    void Update()
    {
        moveCloud(cloudTop);
        moveCloud(cloudBottom);
    }

    /**
     * Moves a given cloud image across the screen.
     */
    public static void moveCloud(Image cloud)
    {
        if (cloud == null) return;

        float cloudWidth = cloud.GetComponent<RectTransform>().rect.width;
        
        Vector3 position = cloud.transform.position;
        position.x -= cloudSpeed * Time.deltaTime;
        if (position.x <= -ResetPosition)
            position.x = ResetPosition + cloudWidth;

        cloud.transform.position = position;
    }
    
    /**
     * Starts the game by loading the game scene.
     */
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    /**
     * Opens the about page in a web browser.
     */
    public void OpenAboutPage()
    {
        Application.OpenURL("https://github.com/rafael-allves");
    }
}
