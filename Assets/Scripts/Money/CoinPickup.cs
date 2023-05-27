using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private CoinsSystem m_CoinsSystem;
    // Start is called before the first frame update
    void Start()
    {
        m_CoinsSystem = FindObjectOfType<CoinsSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("¡the player entered on the trigger! : " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("¡the player entered!");
            m_CoinsSystem.AddCoins(1);
            Destroy(other.gameObject);
        }
    }
}
