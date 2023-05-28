using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float HP = 3.0f;
    public GameObject son;
    private float maxHP;
    public GameObject player;
    
    private GManager m_GManager;

    private void Start()
    {
        m_GManager = FindObjectOfType<GManager>();
    }

    //if player collides trigger gameover in it's script
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collided");
        //log other tag
        //Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().gameOver();
            m_GManager.removeCoins();
        }
        

    }

    public void doDamage(float dmg){
        

        HP -= dmg;
        
        Material mat = son.GetComponent<Renderer>().material;
        if(HP < 3){
            Color a = new Color(1.0f, 0.8f, 0f);
            mat.color = a;
        }
        if(HP < 2){
            Color a = new Color(1.0f, 0.5f, 0f);
            mat.color = a;
        }
        if(HP < 1){
            Color a = new Color(1.0f, 0.2f, 0f);
            mat.color = a;
        }

        if(HP <= 0){
            Destroy(gameObject);
        }

    }
}
