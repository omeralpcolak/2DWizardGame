using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossHydraMovement : MonoBehaviour
{
    private void Start() 
    {
        transform.DOMoveY(1.5f,.5f)
        .SetLoops(-1,LoopType.Yoyo);
    }
}
