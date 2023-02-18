using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour
{   
    Rigidbody2D rbody;
    public float projectileSpeed;
    PlayerHealthController playerHealthController;
    public GameObject enemyAttackHitPrefab;
    public Transform attackHitLocation;


    private void Awake() 
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(enemyAttackHitPrefab,attackHitLocation.transform.position,Quaternion.identity);
        }
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            playerHealthController.TakeDamage();
            Instantiate(enemyAttackHitPrefab,attackHitLocation.transform.position,Quaternion.identity);
        }
    }

    private void Start() 
    {
        rbody= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        //transform.Translate(0f,-Time.deltaTime*projectileSpeed,0f);
        rbody.velocity = new Vector2 (0f,-projectileSpeed);
    }

}
