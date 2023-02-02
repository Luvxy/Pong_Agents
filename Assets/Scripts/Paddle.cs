using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public bool delectable = true;
    public GameObject ball;

    public float deley = 0.2f;

    private int movement;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(isPlayer1 == false){
            if(delectable == true)
            {
                if(ball.transform.position.y < transform.position.y){
                    movement = -1;
                }
                
                else if(ball.transform.position.y > transform.position.y){
                    movement = +1;
                }
                else{
                    movement = 0;
                }
                delectable = false;
                StartCoroutine(CoolTime(deley));
            }

            rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        }
    }

    public void Reset()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
    }
    
    IEnumerator CoolTime(float time){
        yield return new WaitForSeconds(time);
        delectable = true;
    }
}
