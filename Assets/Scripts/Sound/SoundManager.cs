using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;

    private AudioSource m_audioSource;
    public AudioMixer m_AudioMixer;

    private float volume;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;

        m_audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StopSound();
        volume = PlayerPrefs.GetFloat("volume"); 
        SetVolume(volume);
    }

    public void PlaySound(AudioClip clip)
    {
        m_audioSource.PlayOneShot(clip);
    }

    public void StopSound()
    {
        m_audioSource.Stop();
    }

    public void PuaseSound() {
        m_audioSource.Pause();
    }

    public void ResumeSound() {
        m_audioSource.UnPause();
    }
    
    public void SetVolume(float volume)
    {
        float newValue = 0;
        Debug.Log("Chande Audio Mixer volume: " + volume);
        m_AudioMixer.SetFloat("volume", volume);
        
        if (volume == 0) {
            newValue = 1.0f;
        } else if (volume == -80) {
            newValue = 0;
        } else {
            float valueNormalize = (Mathf.Abs(volume) / 80f) * 100f;
            float valueRest = 100f - valueNormalize;
            newValue = valueRest / 100f;

        }
        
        Debug.Log("Chande Audio Source volume: " + newValue);
        m_audioSource.volume = newValue;
    }
}