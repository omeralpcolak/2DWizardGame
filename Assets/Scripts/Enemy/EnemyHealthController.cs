using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int currentHealth,maxHealth;
    public GameObject destructionEffect;


    private void Awake() 
    {
        currentHealth = maxHealth;
    }

    public void EnemyTakeDamage()
    {
        currentHealth--;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
            Instantiate(destructionEffect,transform.position,transform.rotation);
        }
    }
}
