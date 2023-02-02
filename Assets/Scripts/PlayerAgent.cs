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
        float y = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
        Vector3 movement = Vector3.forward*y;
        rb.AddForce(movement.normalized*speed);

        AddReward(0.001f);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
 
    }

}
