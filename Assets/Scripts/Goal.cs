using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!isPlayer1Goal)
            {
                GameObject.Find("Event").GetComponent<Score>().Player1Scored();
            }
            else
            {
                GameObject.Find("Event").GetComponent<Score>().Player2Scored();
            }
        }
    }
}
