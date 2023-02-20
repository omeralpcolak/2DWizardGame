using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthController : MonoBehaviour
{
    public int bossCurrentHealth,bossMaxHealth;
    public GameObject destructionEffect;
    

    private void Awake() 
    {
        bossCurrentHealth = bossMaxHealth;
    }

    public void BossTakeDamage()
    {
        bossCurrentHealth--;
        
        if (bossCurrentHealth<0)
        {
            bossCurrentHealth=0;
            gameObject.SetActive(false);
            Instantiate (destructionEffect,transform.position,transform.rotation);
        }
    }
}
