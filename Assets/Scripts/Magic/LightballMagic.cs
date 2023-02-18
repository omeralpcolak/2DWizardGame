using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightballMagic : MagicBase
{
    public Lightball lightballPrefab;
    public GameObject lightballSpawnPoint;


    public override void Magic()
    {
        Lightball lightball = Instantiate(lightballPrefab,lightballSpawnPoint.transform.position,Quaternion.identity);
    }
}
