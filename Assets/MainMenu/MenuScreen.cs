using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public Image cloudTop, cloudBottom;
    public Button playBtn, aboutBtn;
    public Text bestScore;

    [SerializeField] private static float cloudSpeed = 100f;
    private const float ResetPosition = 1345f;

    private int loadBestScore() { return PlayerPrefs.GetInt("BestScore", 0); }
    
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

    void Update()
    {
        moveCloud(cloudTop);
        moveCloud(cloudBottom);
    }

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
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenAboutPage()
    {
    
        Application.OpenURL("https://github.com/rafael-allves");
    }
}
