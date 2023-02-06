using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player1")]
    public GameObject player1;
    public GameObject player1Gaal;

    [Header("Player2")]
    public GameObject player2;
    public GameObject player2Gaal;

    private int Player1Score;
    private int Player2Score;


    public void Player1Scored()
    {
        player1.GetComponent<PlayerAgent>().Reset();
    }

    public void Player2Scored()
    {
        player1.GetComponent<PlayerAgent>().Reset();
    }

    void ResetBall()
    {
        ball.GetComponent<Ball>().Reset();
        player2.GetComponent<Paddle>().Reset();
    }
}
