using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSystem : MonoBehaviour
{
    public int m_Coins = 0;

    private void Start()
    {
        LoadCoins();
    }

    private void OnApplicationQuit()
    {
        SaveCoins();
    }

    
    public void AddCoins(int coins)
    {
        m_Coins += coins;
    }

    public void RemoveCoins(int coins)
    {
        m_Coins -= coins;
    }
    public void removeTempCoin(int coins) {
        m_Coins = m_Coins - coins;
    }

    public int GetCoins()
    {
        return m_Coins;
    }

    public void SetCoins(int coins)
    {
        m_Coins = coins;
    }

    public bool CanBuy(int coins)
    {
        return m_Coins >= coins;
    }

    public void Buy(int coins)
    {
        m_Coins -= coins;
    }

    public void SaveCoins()
    {
        Debug.Log("Save coins.");
        PlayerPrefs.SetInt("Coins", m_Coins);
        PlayerPrefs.Save();
    }

    public void LoadCoins()
    {
        //check if the key exists
        if (PlayerPrefs.HasKey("Coins"))
        {
            Debug.Log("Load datos.");
            m_Coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            Debug.Log("Loading coins");
            m_Coins = PlayerPrefs.GetInt("Coins");
        }
    }

    public void ResetCoins()
    {
        m_Coins = 0;
    }
}
