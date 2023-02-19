using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireball : MonoBehaviour
{   
    PlayerHealthController playerHealthController;
    public float bossFireballSpeed;
    public Transform hitLocation;
    public Vector2 target;

    private void Start() 
    {
        target = new Vector2 (hitLocation.transform.position.x,hitLocation.transform.position.y);    
    }

    private void Awake() 
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();        
    }

    private void FixedUpdate() 
    {
        transform.position = Vector2.MoveTowards(transform.position,target,Time.deltaTime*bossFireballSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
            
        }
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            playerHealthController.TakeDamage();
        }    
    }
}
