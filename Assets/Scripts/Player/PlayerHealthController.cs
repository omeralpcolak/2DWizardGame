using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{   
    public int maxHealth, currentHealth;
    public GameObject ripPrefab;
    public Transform ripPrefabTransform;
    UIController uiController;

    private void Awake() 
    {
        uiController = Object.FindObjectOfType<UIController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <=0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
            Instantiate(ripPrefab,ripPrefabTransform.transform.position,Quaternion.identity);
        }

        uiController.UpdateHealth();
    }

    public void HealthIncrease()
    {
        currentHealth++;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        uiController.UpdateHealth();
    }

    
}
