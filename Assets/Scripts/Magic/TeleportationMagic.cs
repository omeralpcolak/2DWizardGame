using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationMagic : MagicBase
{
    public GameObject teleportationPoint;
    public GameObject teleportationEffect;
    public GameObject effectLocation1;
    

    public override void Magic()
    {   
        
        Instantiate(teleportationEffect,effectLocation1.transform.position,effectLocation1.transform.rotation);
        playerMovement.transform.position = teleportationPoint.transform.position;
        Instantiate(teleportationEffect,effectLocation1.transform.position,effectLocation1.transform.rotation);
    }
    
}
