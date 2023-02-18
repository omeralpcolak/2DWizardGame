using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HydraMovement : MonoBehaviour
{   

    public Transform wayPoint;
    //bool loopMovement = true;
    // Start is called before the first frame update
    void Start()
    {   
        
        transform.DOMoveY(0.30f,0.50f)
            .SetLoops(-1,LoopType.Yoyo);
    }

    public void HydraMovementFunction()
    {
        transform.DOMoveX(wayPoint.transform.position.x,2f);
    }
    
   
    
}
