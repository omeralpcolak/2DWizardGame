using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMagic : MagicBase
{
    public Fireball fireballPrefab;
    public GameObject fireballSpawnPoint;
    
    


    public override void Magic ()
    {
        Fireball fireball = Instantiate(fireballPrefab,fireballSpawnPoint.transform.position,fireballSpawnPoint.transform.rotation);
        fireball.Init(playerMovement.playerFacingRight);
        
        
    }
}
