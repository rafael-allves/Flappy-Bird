using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public int spawnRate = 5;
    public float heightOffset = 10;
    private float spawnTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer < spawnRate)
            spawnTimer += Time.deltaTime;
        else {
            spawnPipe();
            spawnTimer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        
        Vector3 position = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        
        Instantiate(pipe, position, transform.rotation);
    }
}
