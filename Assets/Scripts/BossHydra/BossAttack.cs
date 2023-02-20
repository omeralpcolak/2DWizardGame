using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{   
    public Transform fireSpawnPoint1,fireSpawnPoint2,fireSpawnPoint3;
    public Transform lightballSpawnPoint1,lightballSpawnPoint2,lightballSpawnPoint3;
    public GameObject bossFireBall;
    public GameObject bossLightball;
    float timerOfInstantiate = 60f;
    PlayerHealthController playerHealthController;
    TriggerBossFight triggerBossFight;
    BossHydraMovement bossHydraMovement;
    

    private void Awake() 
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        triggerBossFight = Object.FindObjectOfType<TriggerBossFight>();
        bossHydraMovement = Object.FindObjectOfType<BossHydraMovement>();
    }


    private void FixedUpdate() 
    {   if (triggerBossFight.canBossAttack == true)
        {   
            if (playerHealthController.currentHealth>0)
            {   
                bossHydraMovement.FollowPlayer();
                timerOfInstantiate--;
                if (timerOfInstantiate<=0)
                {
                    StartCoroutine(BossAttackRoutine());

                    timerOfInstantiate = 60f;
                }
            
            }
        }
        
        
    }

    IEnumerator BossAttackRoutine()
    {
        yield return null;
        Instantiate(bossFireBall,fireSpawnPoint1.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(bossFireBall,fireSpawnPoint2.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(bossFireBall,fireSpawnPoint3.transform.position,Quaternion.identity);
        

        yield return new WaitForSeconds(1f);

        Instantiate(bossLightball,lightballSpawnPoint1.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Instantiate(bossLightball,lightballSpawnPoint2.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Instantiate(bossLightball,lightballSpawnPoint3.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(2f);

    }

}
