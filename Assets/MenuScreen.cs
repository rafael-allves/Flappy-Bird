using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    public Image cloudTop, cloudBottom;
    [SerializeField] private float cloudSpeed = 100f;
    private const float ResetPosition = 1345f;
    
    void Start()
    {
        if(cloudTop == null || cloudBottom == null)
            Debug.LogError("Cloud objects not found. Make sure your tags are set correctly.");

        Debug.Log("MenuScreen started. Clouds initialized." + cloudTop.tag + cloudBottom.tag);
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
}
