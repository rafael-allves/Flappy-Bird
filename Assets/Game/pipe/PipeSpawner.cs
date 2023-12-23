using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    /**
     * The pipe prefab to spawn.
     */
    public GameObject pipe;

    /**
     * The rate at which pipes spawn, in seconds.
     */
    public int spawnRate = 5;

    /**
     * The vertical offset for spawning pipes, creating a range for the height.
     */
    public float heightOffset = 10;

    /**
     * Internal timer to track when the next pipe should be spawned.
     */
    private float spawnTimer = 0;

    /**
     * Start is called before the first frame update.
     * Initial call to spawn a pipe.
     */
    void Start()
    {
        spawnPipe();
    }

    /**
     * Update is called once per frame.
     * Manages the timing and spawning of pipes.
     */
    void Update()
    {
        // Increment the timer based on the time passed
        if(spawnTimer < spawnRate)
            spawnTimer += Time.deltaTime;
        else
        {
            // When the timer reaches the spawn rate, spawn a new pipe and reset the timer
            spawnPipe();
            spawnTimer = 0;
        }
    }

    /**
     * Spawns a pipe at a random height within the specified range.
     */
    void spawnPipe()
    {
        // Calculate the lowest and highest points for spawning
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Generate a random position within the range
        Vector3 position = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        
        // Instantiate a new pipe at the calculated position
        Instantiate(pipe, position, transform.rotation);
    }
}