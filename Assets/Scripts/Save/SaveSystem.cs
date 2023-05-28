using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public void startStrcuture()
    {

        bool permi = false;
        // Create Player Structure
        MusicStructure playerstruc = new MusicStructure { name = "a", m_audioClip = null };

        //Load saved
        string jsonString = PlayerPrefs.GetString("playerlist");

        MusicPj highscores = JsonUtility.FromJson<MusicPj>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            highscores = new MusicPj()
            {
                MusicList = new List<MusicStructure>()
            };
        }

        highscores.MusicList.Add(playerstruc);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("musiclist", json);
        PlayerPrefs.Save();

    }

    public void saveData(string jsonString)
    {
        MusicPj musiclist = JsonUtility.FromJson<MusicPj>(jsonString);

        if (musiclist == null)
        {
            // There's no stored table, initialize
            musiclist = new MusicPj()
            {
                MusicList = new List<MusicStructure>()
            };
        }

        string json = JsonUtility.ToJson(musiclist);
        PlayerPrefs.SetString("musiclist", json);
        PlayerPrefs.Save();
    }

    public string GetMusicList()
    {
        string jsonString = PlayerPrefs.GetString("musiclist");
        return jsonString;
    }

    public class MusicPj
    {
        public List<MusicStructure> MusicList;
    }
    [System.Serializable]
    public class MusicStructure
    {
        public string name;
        public AudioClip m_audioClip;
    }

}
