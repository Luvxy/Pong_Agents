using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player1")]
    public GameObject player1;
    public GameObject player1Gaal;

    [Header("Player2")]
    public GameObject player2;
    public GameObject player2Gaal;

    [Header("Score")]
    public GameObject Player1Text;
    public GameObject Player2Text;

    private int Player1Score;
    private int Player2Score;


    public void Player1Scored()
    {
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        ResetBall();
    }

    public void Player2Scored()
    {
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        ResetBall();
    }

    void ResetBall()
    {
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<Paddle>().Reset();
        player2.GetComponent<Paddle>().Reset();
    }
}
