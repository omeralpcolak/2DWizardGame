using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemyFireballPrefab;

    public GameObject enemyfireBallSpawnPoint;

    EnemyMovement enemyMovement;
    public float timerInstantiate= 0.5f;

    private void Awake() 
    {
        enemyMovement = Object.FindObjectOfType<EnemyMovement>();
    }

    private void FixedUpdate() 
    {
        if (enemyMovement.rbody.velocity.x == 0)
        {
            timerInstantiate -= Time.deltaTime;
            if (timerInstantiate<=0)
            {
                 Instantiate(enemyFireballPrefab,enemyfireBallSpawnPoint.transform.position,enemyfireBallSpawnPoint.transform.rotation);

                 timerInstantiate = 0.5f;
            }
        }
    }

    /*public void Attack ()
    {   
        if (enemyMovement.rbody.velocity.x ==0)
        {
            Instantiate(enemyFireballPrefab,enemyfireBallSpawnPoint.transform.position,enemyfireBallSpawnPoint.transform.rotation);
        }
        
    }*/
}
