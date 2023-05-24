using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float HP = 3.0f;
    public GameObject player;
    //if player collides trigger gameover in it's script
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        //log other tag
        Debug.Log(other.gameObject.tag);
        
        if(other.gameObject.tag == "Player")
            player.GetComponent<PlayerController>().gameOver();
        

    }

    public void doDamage(float dmg){
        HP -= dmg;
        Debug.Log("HP: " + HP);
        if(HP <= 0){
            Destroy(gameObject);
        }

    }
}
