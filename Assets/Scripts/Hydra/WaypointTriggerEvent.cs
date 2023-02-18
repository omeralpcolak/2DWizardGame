using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class WaypointTriggerEvent : MonoBehaviour
{   
    HydraMovement hydraMovement;
    public GameObject pentagramPrefab;
    public GameObject hydra;
    UIController uiController;
    PlayerMovement playerMovement;
    public GameObject fadeScreen;
    
    

    private void Awake() 
    {
        hydraMovement= Object.FindObjectOfType<HydraMovement>();
        uiController = Object.FindObjectOfType<UIController>();
        playerMovement = Object.FindObjectOfType<PlayerMovement>();
            
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {   
            playerMovement.canItMove = false;
            hydraMovement.HydraMovementFunction();
            //uiController.Dialogue();
            StartCoroutine(TeleportationRoutine());
            //Scene changing!!
            
            
        }
    }

    IEnumerator TeleportationRoutine()
    {
        
        yield return null;
        uiController.Dialogue();
        yield return new WaitForSeconds(5f);
        Instantiate(pentagramPrefab,hydra.transform.position,hydra.transform.rotation);
        yield return new WaitForSeconds(2f);
        hydra.transform.DOScale(0f,1f);
        yield return new WaitForSeconds(.1f);
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1,1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("BossLevel");
        
        
    }

}
