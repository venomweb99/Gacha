using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public AdsManager m_AdsManager;

    private CoinsSystem m_CoinsSystem;
    public TextMeshProUGUI m_CoinsText;

    // Start is called before the first frame update
    void Start()
    {
        m_CoinsSystem = GetComponent<CoinsSystem>();
        StartCoroutine(startADSBanner());
        //LoadAllPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshData();
    }

    //refresh coins
    public void RefreshData()
    {
        m_CoinsText.text = m_CoinsSystem.GetCoins().ToString();
    }
    private IEnumerator startADSBanner()
    {
        yield return new WaitForSeconds(10f);
        ShowBannerAds();
    }

    public void ShowBannerAds()
    {
        Debug.Log("GManager Banner Ads");
        m_AdsManager.LoadAd(AdsManager.AD_TYPE.BANNER);
    }

    //public void LoadAllPlayerPrefs() {
    //    m_MenuManager.LoadQuality();
    //    m_MenuManager.LoadVolume(); 
    //}
}
