using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public AdsManager m_AdsManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startADS());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator startADS() {
        yield return new WaitForSeconds(5f);
        m_AdsManager.LoadAd();
        yield return new WaitForSeconds(5f);
        m_AdsManager.ShowAd();
    }
}
