using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public float movementTime, waitingTime;
    float movementTimer, waitingTimer;
    public Transform lefPosition,rightPosition;
    bool enemyFacingRight;
    public Rigidbody2D rbody;
    PlayerHealthController playerHealthController;


    private void Awake() 
    {
        rbody=GetComponent<Rigidbody2D>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void Start() 
    {
        lefPosition.parent = null;
        rightPosition.parent = null;
        enemyFacingRight = true;
        movementTimer=movementTime;
    }

    private void FixedUpdate() 
    {
        EnemyMovementFunction();
    }


    public void EnemyMovementFunction()
    {   
        if (movementTimer>0)
        {
            movementTimer -= Time.deltaTime;
            if(enemyFacingRight)
            {
                rbody.velocity = new Vector2(movementSpeed,rbody.velocity.y);
                if (transform.position.x > rightPosition.position.x)
                {
                    enemyFacingRight = false;
                }
            }
            else
            {
                rbody.velocity = new Vector2 (-movementSpeed,rbody.velocity.y);
                if (transform.position.x < lefPosition.position.x)
                {
                    enemyFacingRight = true;
                }
            }
            if (movementTimer <=0)
            {
                waitingTimer = Random.Range(waitingTime*0.7f,waitingTime*1.2f);
            }
        }
        else if (waitingTimer >0)
        {
            waitingTimer -= Time.deltaTime;
            rbody.velocity = new Vector2 (0,rbody.velocity.y);

            if (waitingTimer<=0)
            {
                movementTimer = Random.Range(movementTime*0.7f,movementTime*1.2f);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            playerHealthController.TakeDamage();
        }

    }

}
