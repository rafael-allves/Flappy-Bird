using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private bool alreadyScored = false;
    private const int deadZone = -35, scoreZone = -4;
    public float moveSpeed = 5;
    public LogicManager logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")
                    .GetComponent<LogicManager>();
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        score();
        destroyPipe();
    }

    private void score()
    {
        if(!alreadyScored && scoreZone >= transform.position.x){
            alreadyScored = true;
            logic.addScore();
        }
    }

    private void destroyPipe()
    {
        if(transform.position.x <= deadZone)
            Destroy(gameObject);
    }
}
