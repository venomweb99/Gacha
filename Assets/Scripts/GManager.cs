using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public AdsManager m_AdsManager;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startADSBanner());
        //LoadAllPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {

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
