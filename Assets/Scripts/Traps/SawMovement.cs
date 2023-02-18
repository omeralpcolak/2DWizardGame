using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SawMovement : MonoBehaviour
{   
    Rigidbody2D rbody;
    public float movementSpeed;
    public Transform wayPoint1, wayPoint2;
    bool trapFacingRight;
    bool trapGoingUp;
    public bool isItHorizontal, isItVertical;
    PlayerHealthController playerHealthController;


    private void Awake() 
    {
        rbody = GetComponent<Rigidbody2D>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        wayPoint1.parent = null;
        wayPoint2.parent = null;
        trapFacingRight = true;
        trapGoingUp = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void FixedUpdate() 
    {
        SawMovementFunction();    
    }

    public void SawMovementFunction()
    {
        if (isItHorizontal)
        {   

           //transform.DOMoveX(wayPoint1.transform.position.x,1f)
            //.SetLoops(-1,LoopType.Restart);



            if(trapFacingRight)
            {
                rbody.velocity = new Vector2(movementSpeed,rbody.velocity.y);
                if (transform.position.x > wayPoint1.transform.position.x)
                {
                    Flip();
                    trapFacingRight = false;
                }
                
            }
            else
            {
                rbody.velocity = new Vector2(-movementSpeed,rbody.velocity.y);
                if (transform.position.x < wayPoint2.transform.position.x)
                {
                    Flip();
                    trapFacingRight=true;
                }
            }

        }
        if (isItVertical)
        {
            if (trapGoingUp)
            {
                rbody.velocity = new Vector2 (rbody.velocity.x,movementSpeed);
                if (transform.position.y > wayPoint1.transform.position.y)
                {
                    trapGoingUp=false;
                }
            }
            else
            {
                rbody.velocity = new Vector2 (rbody.velocity.x,-movementSpeed);
                if (transform.position.y < wayPoint2.transform.position.y)
                {
                    trapGoingUp=true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag=="Player")
        {
            playerHealthController.TakeDamage(); 
        }   
    }

    public void Flip()
    {
        transform.Rotate(0f,180f,0f);
    }

}
