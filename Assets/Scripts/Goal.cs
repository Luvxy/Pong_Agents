using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;
    public GameObject Event;
    public GameObject player1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!isPlayer1Goal)
            {
                Event.GetComponent<Score>().Player1Scored();
                player1.GetComponent<PlayerAgent>().RWagent(1.0f);
            }
            else
            {
                Event.GetComponent<Score>().Player2Scored();
                player1.GetComponent<PlayerAgent>().RWagent(-1.0f);
            }
        }
    }
}
