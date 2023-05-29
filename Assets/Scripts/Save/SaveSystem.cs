using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Newtonsoft.Json;

public class SaveSystem : MonoBehaviour
{
    private static SaveSystem instance;
    public static SaveSystem Instance => instance;

    public List<MusicStructure> m_MusicList;

    public List<string> m_UserMusic;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        m_UserMusic.Add("None");
        LoadMusicData();
    }

    public void LoadMusicData() {
        m_UserMusic.Clear();

        List<string> loadedMusic = JsonConvert.DeserializeObject<List<string>>(GetMusicList());

        if (loadedMusic != null && loadedMusic.Count > 0)
        {
            loadedMusic.Add("None");
            
            foreach (var itemMusic in m_MusicList)
            {
                if (loadedMusic.Contains(itemMusic.name))
                {
                    m_UserMusic.Add(itemMusic.name);
                }
            }
        }
    }

    public List<string> GetListMusic() {
        return m_UserMusic;
    }

    public bool CheckIsOwn(string name) {
        return m_UserMusic.Contains(name);
    }

    public List<MusicStructure> GetGeneralList() {
        return m_MusicList;
    }
    public void addMusic(string name)
    {
        m_UserMusic.Add(name);
        saveData(m_UserMusic);
    }
    public void saveData(object jsonString)
    {
        string jsonlist = JsonConvert.SerializeObject(jsonString);
        Debug.Log("jsonlist: " + jsonlist);
        PlayerPrefs.SetString("musiclist", jsonlist);
        PlayerPrefs.Save();
    }

    public void SaveDefaultMusic(string namemusic)
    {
        Debug.Log("SaveDefaultMusic:  " + namemusic);
        PlayerPrefs.SetString("defaultmusic", namemusic);
        PlayerPrefs.Save();
    }

    public static string GetMusicList()
    {
        Debug.Log("GetMusicList:  " + PlayerPrefs.GetString("musiclist"));
        return PlayerPrefs.GetString("musiclist") ?? null;
    }

    public string GetDefaultMusic() {
        return PlayerPrefs.GetString("defaultmusic") ?? null;
    }

    [Serializable]
    public class MusicStructure
    {
        public string name;
        public AudioClip m_audioClip;
    }

}
