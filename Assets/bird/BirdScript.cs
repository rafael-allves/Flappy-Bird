using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float jumpForce = 10;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            birdRigidBody.velocity = Vector2.up * jumpForce;
    }
}
