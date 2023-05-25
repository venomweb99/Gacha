using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.Rendering;

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
    public GameObject m_SettingsPanel;

    public TextMeshProUGUI m_CoinsText;

    public TextMeshProUGUI m_MainName;

    public TMP_InputField m_InputName;

    public int m_QualityLevel = 1;
    public TMP_Dropdown m_QualityDropdown;

    public AudioMixer m_AudioMixer;
    public float m_volume = 0.0f;
    public Slider m_SliderVolume;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(startADSBanner());
       RefreshData();
       GetName();
       LoadQuality();
       LoadVolume();
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

    public void OpenSettings()
    {
        m_ButtonsPanel.SetActive(false);
        m_SettingsPanel.SetActive(true);
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

    public void BackSettingsToMain() {
        m_SettingsPanel.SetActive(false);
        m_ButtonsPanel.SetActive(true);
    }
    private IEnumerator ReactivateButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isButtonActive = true;
        m_freecoins.interactable = true;
    }

    public void SetName()
    {
        Debug.Log("Name: " + m_InputName.text);
        m_MainName.text = "Name: " + m_InputName.text;
        PlayerPrefs.SetString("mainname", m_InputName.text);
    }

    public void GetName()
    {
        if (PlayerPrefs.HasKey("mainname"))
        {
            m_MainName.text = "Name: " + PlayerPrefs.GetString("mainname");
        }
        else
        {
            m_MainName.text = "Name: N/A";
        }
    }

    public void SetQuality(int qualityIndex)
    {
        m_QualityLevel = qualityIndex;
    }

    public void SaveQuality()
    {
        QualitySettings.SetQualityLevel(m_QualityLevel);
        PlayerPrefs.SetInt("qualitygeneral", m_QualityLevel);
    }


    public void LoadQuality()
    {
        if (PlayerPrefs.HasKey("qualitygeneral"))
        {
            m_QualityLevel = PlayerPrefs.GetInt("qualitygeneral");
            m_QualityDropdown.value = m_QualityLevel;
            QualitySettings.SetQualityLevel(m_QualityLevel);
            Debug.Log("Cargando graficos" + m_QualityLevel);
        }
        else
        {
            m_QualityLevel = 1;
            QualitySettings.SetQualityLevel(m_QualityLevel);
        }
    }

    public void SetVolume(float volume)
    {
        m_AudioMixer.SetFloat("volume", volume);
        m_volume = volume;
        Debug.Log("Set volume: " + volume);
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("volume", m_volume);
        Debug.Log("Save volume: " + m_volume);
    }

    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            m_volume = PlayerPrefs.GetFloat("volume");
            m_AudioMixer.SetFloat("volume", m_volume);
            m_SliderVolume.value = m_volume;
            Debug.Log("Load volume: " + m_volume);
        }
        else
        {
            Debug.Log("Load default volume: " + m_volume);
            m_AudioMixer.SetFloat("volume", m_volume);
        }
    }
}
