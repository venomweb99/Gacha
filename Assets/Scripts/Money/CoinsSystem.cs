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
        Debug.Log("Guardando datos.");
        PlayerPrefs.SetInt("Coins", m_Coins);
    }

    public void LoadCoins()
    {
        //check if the key exists
        if (PlayerPrefs.HasKey("Coins"))
        {
            Debug.Log("Cargando datos.");
            m_Coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            Debug.Log("Hay datos, cargando datos.");
            m_Coins = PlayerPrefs.GetInt("Coins");
        }
    }

    public void ResetCoins()
    {
        m_Coins = 0;
    }
}
