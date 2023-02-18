using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int fireballSpeed;
    private int direction;
    [SerializeField] GameObject explosionEffect;
    EnemyHealthController enemyHealthController;
    
    
    //PlayerMovement playerMovement;

    
    private void Awake() 
    {
        enemyHealthController = Object.FindObjectOfType<EnemyHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Ground")
        {
            Destroy(gameObject);
            Instantiate(explosionEffect,transform.position,transform.rotation);
            //Destroy(explosionEffect.gameObject,0.5f);
        }
        if (other.tag == "Enemy")
        {   
            Destroy(gameObject);
            enemyHealthController.EnemyTakeDamage();
            Instantiate(explosionEffect,transform.position,transform.rotation);
        }
        if (other.tag == "Hydra")
        {
            Destroy(gameObject);
            Instantiate(explosionEffect,transform.position,transform.rotation);
        }
        
    }

    private void FixedUpdate() 
    {
        if (direction ==0)
        {
            Debug.Log("direction is zero!");
        }
        else
        {
            transform.Translate(-direction*transform.right*fireballSpeed*Time.deltaTime);
        }
    }

    public void Init (bool playerFacingRight)
    {
        direction = playerFacingRight?1:-1;
    }

    public void Init()
    {
        direction = 0;
    }
}
