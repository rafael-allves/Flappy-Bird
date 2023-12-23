using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    /**
     * Flag to check if the pipe has already been scored.
     */
    private bool alreadyScored = false;

    /**
     * Constants for the dead zone and score zone positions.
     */
    private const int deadZone = -35, scoreZone = -4;

    /**
     * Speed at which the pipe moves.
     */
    public float moveSpeed = 5;

    /**
     * Reference to the game's logic manager.
     */
    public LogicManager logic;

    /**
     * Start is called before the first frame update.
     * Initializes the logic manager by finding the object with the "Logic" tag.
     */
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")
                    .GetComponent<LogicManager>();
    }

    /**
     * Update is called once per frame.
     * Handles pipe movement, scoring, and destruction.
     */
    void Update()
    {
        // Move the pipe leftwards based on moveSpeed
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // Call score method
        score();

        // Call destroyPipe method
        destroyPipe();
    }

    /**
     * Handles the scoring logic when the pipe passes a certain point.
     */
    private void score()
    {
        // Increase score if the game is not over, the pipe hasn't been scored yet, and it passes the score zone
        if(!logic.isGameOver && !alreadyScored && 
            scoreZone >= transform.position.x){
            alreadyScored = true; // Set flag to true after scoring
            logic.addScore(); // Call addScore method on LogicManager
        }
    }

    /**
     * Destroys the pipe when it reaches the dead zone.
     */
    private void destroyPipe()
    {
        // Destroy the game object when it passes the dead zone
        if(transform.position.x <= deadZone)
            Destroy(gameObject);
    }
}
