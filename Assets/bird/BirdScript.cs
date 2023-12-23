using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float jumpForce = 10;
    private LogicManager logic;
    private bool isRotating = false; // To check if rotation is in progress

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    void Update()
    {
        if (!logic.isGameOver && Input.GetKeyDown(KeyCode.Space))
            jump();

        if (transform.position.y <= -21 || transform.position.y >= 21)
            logic.gameOver();

        if (isRotating)
        {
            RotateBack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
    }

    private void jump()
    {
        birdRigidBody.velocity = Vector2.up * jumpForce;
        transform.rotation = Quaternion.Euler(0, 0, 45);
        isRotating = true;
    }

    private void RotateBack()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5);

        if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0, 0, 0)) < 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isRotating = false;
        }
    }
}
