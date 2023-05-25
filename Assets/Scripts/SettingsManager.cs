using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public int m_QualityLevel = 1;
    public AudioMixer m_AudioMixer;
    public float m_volume = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadQuality();
        LoadVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadQuality()
    {
        if (PlayerPrefs.HasKey("qualitygeneral"))
        {
            m_QualityLevel = PlayerPrefs.GetInt("qualitygeneral");
            QualitySettings.SetQualityLevel(m_QualityLevel);
            Debug.Log("Cargando graficos" + m_QualityLevel);
        }
        else
        {
            m_QualityLevel = 1;
            QualitySettings.SetQualityLevel(m_QualityLevel);
        }
    }
    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            m_volume = PlayerPrefs.GetFloat("volume");
            m_AudioMixer.SetFloat("volume", m_volume);
            Debug.Log("Load volume: " + m_volume);
        }
        else
        {
            Debug.Log("Load default volume: " + m_volume);
            m_AudioMixer.SetFloat("volume", m_volume);
        }
    }
}
