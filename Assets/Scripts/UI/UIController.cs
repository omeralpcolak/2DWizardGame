using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField]TMP_Text gemTxt;
    [SerializeField]Image heart1Img, heart2Img, heart3Img;
    [SerializeField]Sprite fullHearth,halfHearth,emptyHearth;
    LevelManager levelManager;
    PlayerHealthController playerHealthController;
    [SerializeField]TMP_Text dialogueTxt,victoryLossTxt;
    [SerializeField]GameObject dialogueBackground;
    [SerializeField]GameObject fadeScreen;

    private void Awake() 
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    public void UpdateCollectedGems()
    {
        gemTxt.text = levelManager.collectedGems.ToString();
    }

    public void UpdateHealth()
    {
        switch (playerHealthController.currentHealth)
        {
            case 6:
                heart1Img.sprite = fullHearth;
                heart2Img.sprite = fullHearth;
                heart3Img.sprite = fullHearth;
                break;
            case 5:
                heart1Img.sprite = fullHearth;
                heart2Img.sprite = fullHearth;
                heart3Img.sprite = halfHearth;
                break;
            case 4:
                heart1Img.sprite = fullHearth;
                heart2Img.sprite = fullHearth;
                heart3Img.sprite = emptyHearth;
                break;
            case 3:
                heart1Img.sprite = fullHearth;
                heart2Img.sprite = halfHearth;
                heart3Img.sprite = emptyHearth;
                break;
            case 2:
                heart1Img.sprite = fullHearth;
                heart2Img.sprite = emptyHearth;
                heart3Img.sprite = emptyHearth;
                break;
            case 1:
                heart1Img.sprite = halfHearth;
                heart2Img.sprite = emptyHearth;
                heart3Img.sprite = emptyHearth;
                break;
            case 0:
                heart1Img.sprite = emptyHearth;
                heart2Img.sprite = emptyHearth;
                heart3Img.sprite = emptyHearth;
                break;


        }
    }


    public void Dialogue()
    {
        StartCoroutine(DialogueRoutine());
    }
    public void FinalDialogue()
    {
        StartCoroutine(FinalTalk());
    }
    public void WinGame()
    {
        StartCoroutine(Win());
    }
    public void DefeatGame()
    {
        StartCoroutine(Defeat());
    }

    IEnumerator DialogueRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        dialogueBackground.GetComponent<CanvasGroup>().DOFade(1,0f);
        dialogueTxt.text = "You basic mortal!! YOU WILL NEVER CATCH ME !!!";
        dialogueTxt.GetComponent<CanvasGroup>().DOFade(1,1f);
        yield return new WaitForSeconds(2f);
        dialogueTxt.text = "HAHAHAHAHAHAHAHAHA!! Bye Bye Mortal!!";
        yield return new WaitForSeconds(1.5f);
        dialogueTxt.GetComponent<CanvasGroup>().DOFade(0,1f);
        yield return new WaitForSeconds(0.3f);
        dialogueBackground.GetComponent<CanvasGroup>().DOFade(0,1f);
        
    }

    IEnumerator FinalTalk()
    {
        yield return new WaitForSeconds(1.5f);
        dialogueBackground.GetComponent<CanvasGroup>().DOFade(1,0f);
        dialogueTxt.text = "Do you really believe that you can destroy me ?";
        dialogueTxt.GetComponent<CanvasGroup>().DOFade(1,1f);
        yield return new WaitForSeconds(2f);
        dialogueTxt.text = "HAHAHAHAHAHAHAHAA, I WILL DESTROY YOUU !!!";
        yield return new WaitForSeconds(1.5f);
        dialogueTxt.GetComponent<CanvasGroup>().DOFade(0,1f);
        yield return new WaitForSeconds(0.3f);
        dialogueBackground.GetComponent<CanvasGroup>().DOFade(0,1f);
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
        victoryLossTxt.text = "VICTORY!!";
        victoryLossTxt.GetComponent<CanvasGroup>().DOFade(1,1f);
        yield return new WaitForSeconds(1f);
        victoryLossTxt.GetComponent<CanvasGroup>().DOFade(0,1f);
        yield return new WaitForSeconds(.1f);
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1,1f);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Defeat()
    {
        yield return new WaitForSeconds(1f);
        victoryLossTxt.text = "DEFEAT!!";
        victoryLossTxt.GetComponent<CanvasGroup>().DOFade(1,1f);
        yield return new WaitForSeconds(1f);
        victoryLossTxt.GetComponent<CanvasGroup>().DOFade(0,1f);
        yield return new WaitForSeconds(.1f);
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1,1f);
        yield return new WaitForSeconds(1f);
    }
    
}
