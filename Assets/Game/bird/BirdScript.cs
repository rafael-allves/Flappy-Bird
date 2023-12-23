using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    /**
     * Rigidbody2D component of the bird for physics calculations.
     */
    public Rigidbody2D birdRigidBody;

    /**
     * Force applied to the bird when it jumps.
     */
    public float jumpForce = 9;

    /**
     * Reference to the game's logic manager.
     */
    private LogicManager logic;

    /**
     * Flag to check if the bird is rotating.
     */
    private bool isRotating = false;

    /**
     * Start is called before the first frame update.
     * Initializes the logic manager by finding the object with the "Logic" tag.
     */
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    /**
     * Update is called once per frame.
     * Handles the bird's jump and rotation behavior, and checks for game over conditions.
     */
    void Update()
    {
        // Check for jump input and perform jump if the game is not over
        if (!logic.isGameOver && Input.GetKeyDown(KeyCode.Space))
            jump();

        // Check for game over conditions based on the bird's position
        if (transform.position.y <= -21 || transform.position.y >= 21)
            logic.gameOver();

        // Rotate the bird back to a neutral position if it's currently rotating
        if (isRotating)
            rotateBack();

        // Rotate the bird downwards if it's falling and not rotating
        if (birdRigidBody.velocity.y < 0 && !isRotating)
            rotateDown();
    }

    /**
     * Handles collision events.
     * Triggers game over when the bird collides with an object.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
    }

    /**
     * Makes the bird jump and starts the rotation.
     */
    private void jump()
    {
        birdRigidBody.velocity = Vector2.up * jumpForce; // Apply upward force
        transform.rotation = Quaternion.Euler(0, 0, 30); // Rotate bird upwards
        isRotating = true; // Set rotating flag to true
    }

    /**
     * Rotates the bird back to a neutral position.
     */
    private void rotateBack()
    {
        // Gradually rotate back to a neutral position
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5);

        // Check if rotation is complete
        if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0, 0, 0)) < 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Set rotation to neutral
            isRotating = false; // Set rotating flag to false
        }
    }

    /**
     * Rotates the bird downwards when it's falling.
     */
    private void rotateDown()
    {
        // Gradually rotate downwards
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -30), Time.deltaTime * 5);
    }
}
