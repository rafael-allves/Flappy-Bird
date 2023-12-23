using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float jumpForce = 10;
    private LogicManager logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")
                    .GetComponent<LogicManager>();
    }

    void Update()
    {
        if(!logic.gameOver && Input.GetKeyDown(KeyCode.Space))
            birdRigidBody.velocity = Vector2.up * jumpForce;
    }
}
