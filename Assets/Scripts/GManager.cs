using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    public AdsManager m_AdsManager;

    private CoinsSystem m_CoinsSystem;
    public TextMeshProUGUI m_CoinsText;
    public TextMeshProUGUI m_Level;
    private PlayerController m_player;

    public GameObject m_InfoPanel;

    public GameObject m_PuasePanel;
    public GameObject m_randomSkin;
    private GameObject m_GachaSkin;
    private bool spawnOnce = false;

    private int m_CoinTempLevel = 0;

    public AudioClip fondoClip;

    // Start is called before the first frame update
    void Start()
    {
        m_CoinsSystem = GetComponent<CoinsSystem>();
        m_player = FindObjectOfType<PlayerController>();
        LoadGame();
        StartCoroutine(startADSBanner());
        // Calls the "Task" function every 10 seconds after an initial delay of 0 seconds
        InvokeRepeating("SaveGame", 0f, 5f);
        SoundManager.Instance.PlaySound(fondoClip);
        
    }


    // Update is called once per frame
    void Update()
    {
        RefreshData();
    }

    public void AddTempCoins(int coins)
    {
        m_CoinTempLevel += coins;
    }

    public void removeCoins() {
        m_CoinsSystem.removeTempCoin(m_CoinTempLevel);
        m_CoinsSystem.SaveCoins();
        m_CoinTempLevel = 0;
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("PlayerLevel", m_player.level);
        m_CoinsSystem.SaveCoins();
    }

    public void LoadGame() {
        m_player.level = PlayerPrefs.GetInt("PlayerLevel");
    }
    

    //refresh coins
    public void RefreshData()
    {
        m_CoinsText.text = m_CoinsSystem.GetCoins().ToString();
        m_Level.text = m_player.level.ToString();
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

    public void NextLevel() {
        if(spawnOnce == false)
        {
            spawnOnce = true;
            m_player.level++;
            SaveGame();
            Debug.Log("Next Level");
            m_GachaSkin = Instantiate(m_randomSkin, new Vector3(-2.1f, 1.9f, 0), Quaternion.identity);
            //generate random skin
            m_GachaSkin.GetComponent<Chargen>().createRandom();
        }
        m_InfoPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        m_InfoPanel.SetActive(false);
        m_player.gameOver();
        Time.timeScale = 1;
    }

    public void LoadPartsPassLevel() {
        
        //transfer to player
        m_GachaSkin.GetComponent<Chargen>().transferToPlayer();
        m_player.SaveParts();

        //next level if you win
        RestartLevel();
    }

    public void PausePanelRestartLevel() {
        removeCoins();
        RestartLevel();
    }

    public void PauseOrResumeGame() {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        if (Time.timeScale == 0)
        {
            m_PuasePanel.SetActive(true);
            m_player.PauseMovememnt(false);
            SoundManager.Instance.PuaseSound();
        }
        else
        {
            m_PuasePanel.SetActive(false);
            m_player.PauseMovememnt(true);
            SoundManager.Instance.ResumeSound();
        }
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    
}
