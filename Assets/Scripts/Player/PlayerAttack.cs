using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<MagicBase> magics;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            /*magics.ForEach(x=>{
                x.Magic();
            });*/
            magics[0].Magic();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            magics[1].Magic();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            magics[2].Magic();
        }
    }
}
