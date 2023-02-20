using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerBossFight : MonoBehaviour
{
    public bool canBossAttack;
    UIController uiController;
    PlayerMovement playerMovement;

    private void Awake() 
    {
        uiController=Object.FindObjectOfType<UIController>();
        playerMovement = Object.FindObjectOfType<PlayerMovement>();
    }

    void Start()
    {
        canBossAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            playerMovement.canItMove=false;
            StartCoroutine(BossFinalDialogue());
            
        }    
    }

    IEnumerator BossFinalDialogue()
    {
        yield return null;
        uiController.FinalDialogue();
        yield return new WaitForSeconds(5f);
        canBossAttack = true;
        playerMovement.canItMove=true;
        gameObject.SetActive(false);
    }
}
