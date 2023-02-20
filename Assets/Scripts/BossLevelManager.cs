using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class BossLevelManager : MonoBehaviour
{   
    PlayerHealthController playerHealthController;
    BossHealthController bossHealthController;
    UIController uiController;
    

    private void Awake() 
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        bossHealthController = Object.FindObjectOfType<BossHealthController>();
        uiController = Object.FindObjectOfType<UIController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        VictoryOrDefeat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VictoryOrDefeat()
    {
        if (bossHealthController.bossCurrentHealth == 0)
        {
            
            StartCoroutine(VictoryEnd());
        }
        if (playerHealthController.currentHealth == 0)
        {
            StartCoroutine(DefeatEnd());
        }


    }

    IEnumerator VictoryEnd()
    {
        uiController.WinGame();
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator DefeatEnd()
    {
        uiController.DefeatGame();
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
