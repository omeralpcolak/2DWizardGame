using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightball : MonoBehaviour
{   
    public float lightballSpeed;
    Rigidbody2D rbody;
    public GameObject explosionEffect;
    public GameObject hitLocation;
    EnemyHealthController enemyHealthController;

    private void Awake() 
    {
        enemyHealthController = Object.FindObjectOfType<EnemyHealthController>();
    }

    private void Start() 
    {
        rbody = GetComponent<Rigidbody2D>();   
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            enemyHealthController.EnemyTakeDamage();
            Instantiate(explosionEffect,hitLocation.transform.position, hitLocation.transform.rotation);
        }
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(explosionEffect, hitLocation.transform.position,hitLocation.transform.rotation);
        }
    }

    private void FixedUpdate() 
    {
        rbody.velocity = new Vector2 (0f,lightballSpeed);
    }
}
