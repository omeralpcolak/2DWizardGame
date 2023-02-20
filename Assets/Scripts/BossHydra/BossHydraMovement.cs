using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossHydraMovement : MonoBehaviour
{   
    public GameObject playerPrefab;
    private void Start() 
    {
        transform.DOMoveY(1.5f,.5f)
        .SetLoops(-1,LoopType.Yoyo);
    }

    public void FollowPlayer()
    {
        transform.DOMoveX(playerPrefab.transform.position.x,30f);
        transform.DOMoveY(1.5f,.5f)
        .SetLoops(-1,LoopType.Yoyo);
    }
}
