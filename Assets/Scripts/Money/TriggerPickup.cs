using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPickup : MonoBehaviour
{
    private CoinsSystem m_CoinsSystem;
    private GManager m_GManager;
    public AudioClip m_SoundCoin;
    public AudioClip m_SoundFinish;
    // Start is called before the first frame update
    void Start()
    {
        m_CoinsSystem = FindObjectOfType<CoinsSystem>();
        m_GManager = FindObjectOfType<GManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�the player entered on the trigger! : " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("�the player entered!");
            m_CoinsSystem.AddCoins(1);
            m_GManager.AddTempCoins(1);
            SoundManager.Instance.PlaySound(m_SoundCoin);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Grid"))
        {
            Debug.Log("Finish Game ");
            SoundManager.Instance.PlaySound(m_SoundFinish);
            StartCoroutine(ShowGacha());
        }
    }
    IEnumerator ShowGacha()
    {
        yield return new WaitForSeconds(1.5f);
        m_GManager.NextLevel();
    }
}
