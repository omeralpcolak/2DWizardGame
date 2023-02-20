using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossFireball : MonoBehaviour
{   
    PlayerHealthController playerHealthController;
    public float bossFireballSpeed;
    public GameObject hitLocation;
    Transform target;
    public GameObject explosionEffect;
    public GameObject effectHitLocation;
    

    private void Start() 
    {       
        hitLocation = GameObject.FindWithTag("HitLocation");
        target = hitLocation.transform;
        
        
    }

    private void Awake() 
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>(); 
               
    }

    private void Update() 
    {   
        Shoot();
        /*Vector3 pos = transform.position;
        Vector3 direction = (pos-target.transform.position).normalized;
        rbody.velocity = new Vector3 (direction.x,direction.y,direction.z);*/
        //transform.position = Vector2.MoveTowards(transform.position,target.position,Time.deltaTime*bossFireballSpeed);
    }

    public void Shoot()
    {   
       transform.DOMove(target.transform.position,2f);
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(explosionEffect,effectHitLocation.transform.position,effectHitLocation.transform.rotation);
            
        }
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            playerHealthController.TakeDamage();
            Instantiate(explosionEffect,effectHitLocation.transform.position,effectHitLocation.transform.rotation);
        }    
    }
}
