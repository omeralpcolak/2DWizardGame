using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    public GameObject startBtn,exitBtn;
    public GameObject wizardImage,hydraImage;
    public GameObject gameTitle;
    public GameObject fadeScreen;
    void Start()
    {
        StartCoroutine(MainMenuOpenning());
    }

    
    void Update()
    {
        
    }

    IEnumerator MainMenuOpenning()
    {
        yield return new WaitForSeconds(.5f);
        gameTitle.GetComponent<CanvasGroup>().DOFade(1,.5f);
        yield return new WaitForSeconds(.5f);
        wizardImage.GetComponent<CanvasGroup>().DOFade(1,.5f);
        yield return new WaitForSeconds(.5f);
        startBtn.GetComponent<CanvasGroup>().DOFade(1,.5f);
        startBtn.GetComponent<RectTransform>().DOScale(1,.5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(.5f);
        exitBtn.GetComponent<CanvasGroup>().DOFade(1,.5f);
        exitBtn.GetComponent<RectTransform>().DOScale(1,.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.5f);
        hydraImage.GetComponent<CanvasGroup>().DOFade(1,.5f);
        
    }

    public void PlayGame()
    {
        StartCoroutine(PlayGameRoutine());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator PlayGameRoutine()
    {
        yield return new WaitForSeconds(.1f);
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1,1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level1");
    }
}
