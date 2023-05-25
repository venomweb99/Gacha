using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AdsManager m_AdsManager;
    public float timeBetweenAds = 30f;
    public bool isButtonActive = true;
    public Button m_freecoins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseApp() {
        Application.Quit();
    }
    public void ShowAds()
    {
        if (isButtonActive)
        {
            m_AdsManager.LoadAd(AdsManager.AD_TYPE.REWARD);
            isButtonActive = false;
            m_freecoins.interactable = false;
            StartCoroutine(ReactivateButtonAfterDelay(timeBetweenAds));
        }
    }
    private IEnumerator ReactivateButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isButtonActive = true;
        m_freecoins.interactable = true;
    }
}
