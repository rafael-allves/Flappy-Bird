using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public Image cloudTop, cloudBottom;
    public Button playBtn, aboutBtn;

    [SerializeField] private float cloudSpeed = 100f;
    private const float ResetPosition = 1345f;
    
    void Start()
    {
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
        MoveCloud(cloudTop);
        MoveCloud(cloudBottom);
    }

    private void MoveCloud(Image cloud)
    {
        float cloudWidth = cloud.GetComponent<RectTransform>().rect.width;
        
        Vector3 position = cloud.transform.position;
        position.x -= cloudSpeed * Time.deltaTime;
        if (position.x <= -ResetPosition)
            position.x = ResetPosition + cloudWidth;

        Debug.Log(cloud.name + " position: " + position.x);
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