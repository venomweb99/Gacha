using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public AdsManager m_AdsManager;
    public CoinsSystem m_CoinsSystem;
    public float timeBetweenAds = 30f;
    public bool isButtonActive = true;
    public Button m_freecoins;
    

    public GameObject m_ButtonsPanel;
    public GameObject m_ShopPanel;
    public GameObject m_HelpPanel;

    public TextMeshProUGUI m_CoinsText;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(startADSBanner());
        RefreshCoins();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshCoins();
    }

    //refresh coins
    public void RefreshCoins()
    {
        m_CoinsText.text = m_CoinsSystem.GetCoins().ToString();
    }

    private IEnumerator startADSBanner()
    {
        while (!m_AdsManager.IsInitialize())
        {
            yield return new WaitForSeconds(0.5f);
        }
        m_AdsManager.LoadAd(AdsManager.AD_TYPE.BANNER);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseApp() {
        Application.Quit();
    }

    public void OpenShop() {
        m_ButtonsPanel.SetActive(false);
        m_ShopPanel.SetActive(true);
    }

    public void OpenHelp() {
        m_ButtonsPanel.SetActive(false);
        m_HelpPanel.SetActive(true);
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

    public void BackHelpToMain() {
        m_HelpPanel.SetActive(false);
        m_ButtonsPanel.SetActive(true);
    }

    public void BackShopToMain()
    {
        m_ShopPanel.SetActive(false);
        m_ButtonsPanel.SetActive(true);
    }
    private IEnumerator ReactivateButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isButtonActive = true;
        m_freecoins.interactable = true;
    }
}
