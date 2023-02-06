using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;

public class PlayerAgent : Agent
{
    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    public GameObject player1Gaal;
    public GameObject player2Gaal;
    public GameObject start;
    public Rigidbody2D rb;
    public float speed = 5;

    public float deley = 0.2f;

    private Vector3 startPosition;
    private float movement;

    public void RWagent(float reward)
    {
        AddReward(reward);
    }

    public override void Initialize()
    {
        startPosition = start.transform.localPosition;
    }

    public override void OnEpisodeBegin()
    {
        ball.GetComponent<Ball>().Reset();
        player2.GetComponent<Paddle>().Reset();
        transform.position = startPosition - new Vector3(8, 0, 0);
        rb.velocity = Vector2.zero;
    }

    public override void CollectObservations(Unity.MLAgents.Sensors.VectorSensor sensor)
    {
        sensor.AddObservation(ball.transform.position);
        sensor.AddObservation(player1.transform.position);
        sensor.AddObservation(player1Gaal.transform.position);
        sensor.AddObservation(player2Gaal.transform.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        
        int discrete = actions.DiscreteActions[0];
        
        //discrete = 1 -> down
        //discrete = 2 -> up
        if(discrete == 0)
        {
            movement = -1;
        }
        else if(discrete == 1)
        {
            movement = 1;
        }

        rb.velocity = new Vector2(rb.velocity.x, movement * speed);

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;

        if(Input.GetKey(KeyCode.W))
        {
            discreteActionsOut[0] = 1;
            Debug.Log("up");
        }
        else if(Input.GetKey(KeyCode.S))
        {
            discreteActionsOut[0] = 0;
            Debug.Log("down");
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Ball")){
            AddReward(1.0f);
        }
    }

}
