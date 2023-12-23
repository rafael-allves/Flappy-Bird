using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private int deadZone = -35;
    public float moveSpeed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        destroyPipe();
    }

    void destroyPipe()
    {
        if(transform.position.x <= deadZone)
            Destroy(gameObject);

    }
}
