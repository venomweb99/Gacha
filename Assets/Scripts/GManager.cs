using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public GameObject m_AdsPanel;
    public AdsManager m_AdsManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startADS());
        StartCoroutine(startADSBanner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator startADS()
    {
        yield return new WaitForSeconds(5f);
        m_AdsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator startADSBanner()
    {
        yield return new WaitForSeconds(10f);
        ShowBannerAds();
    }

    public void CloseAdsPanel()
    {
        m_AdsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowAds()
    {
        m_AdsManager.LoadAd(AdsManager.AD_TYPE.INTERSTITIAL);
        m_AdsPanel.SetActive(false);
    }

    public void ShowBannerAds()
    {
        m_AdsManager.LoadAd(AdsManager.AD_TYPE.BANNER);
    }
}
