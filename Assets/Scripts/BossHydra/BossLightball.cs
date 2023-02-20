using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLightball : MonoBehaviour
{   
    Rigidbody2D rbody;
    public float lightballSpeed;
    PlayerHealthController playerHealthController;
    public GameObject lightballExplosionEffect;
    public GameObject effectLocation;


    private void Awake() 
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbody.velocity = new Vector2 (0f,-lightballSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag =="Ground")
        {
            Destroy(gameObject);
            Instantiate(lightballExplosionEffect,effectLocation.transform.position,transform.rotation);
        }
        if (other.tag =="Player")
        {
            Destroy(gameObject);
            Instantiate(lightballExplosionEffect,effectLocation.transform.position,transform.rotation);
            playerHealthController.TakeDamage();
            
        }
    }
}

