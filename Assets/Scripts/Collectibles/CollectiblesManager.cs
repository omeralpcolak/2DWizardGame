using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{
    [SerializeField] bool isItGem, isItCherry;
    public GameObject collectingEffect;
    bool collected;
    PlayerHealthController playerHealthController;
    LevelManager levelManager;
    UIController uiController;

    private void Awake() 
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
        uiController = Object.FindObjectOfType<UIController>();
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")&& !collected)
        {
            if (isItGem)
            {   
                levelManager.collectedGems++;
                collected = true;
                Destroy(gameObject);
                Instantiate(collectingEffect,transform.position,transform.rotation);
                uiController.UpdateCollectedGems();
            }

            if (isItCherry)
            {
                if (playerHealthController.currentHealth != playerHealthController.maxHealth)
                {
                    collected = true;
                    Destroy(gameObject);
                    Instantiate(collectingEffect,transform.position,transform.rotation);
                    playerHealthController.HealthIncrease();
                }
            }
        }
    }
}
