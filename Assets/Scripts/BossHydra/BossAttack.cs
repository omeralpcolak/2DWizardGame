using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{   
    public Transform fireSpawnPoint1,fireSpawnPoint2,fireSpawnPoint3;
    public GameObject bossFireBall;
    public float timerOfInstantiate = 60f;


    private void FixedUpdate() 
    {
        timerOfInstantiate--;
        if (timerOfInstantiate<=0)
        {
            Instantiate(bossFireBall,fireSpawnPoint1.transform.position,Quaternion.identity);
            Instantiate(bossFireBall,fireSpawnPoint2.transform.position,Quaternion.identity);
            Instantiate(bossFireBall,fireSpawnPoint3.transform.position,Quaternion.identity);

            timerOfInstantiate = 60f;
        }
    }
}
