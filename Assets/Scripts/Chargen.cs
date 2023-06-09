using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chargen : MonoBehaviour
{
    public GameObject baseHair;
    public GameObject baseSkin;
    public GameObject baseClothes;
    public GameObject baseShoes;
    private GameObject player;
    public int[] parts;
    public int weapon;
    public float atkSpeed = 2.0f;
    public float dmg = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        setParts();
        if(parts[0]>3){
            weapon = 1;
        }else{
            weapon = 0;
        }
    }

    void createSeeded(int h, int s, int c, int sh){
        parts[0] = h;
        parts[1] = s;
        parts[2] = c;
        parts[3] = sh;
    }

    public void createRandom(){
        parts[0] = Random.Range(0, 7);
        parts[1] = Random.Range(0, 7);
        parts[2] = Random.Range(0, 7);
        parts[3] = Random.Range(0, 7);
    }

    Color getColor(int color){
        return player.GetComponent<PlayerController>().getColor(color);
    }

    void setParts(){

        //set the color of the player parts based on the color variables
        baseHair.GetComponent<Renderer>().material.color = getColor(parts[0]);
        baseSkin.GetComponent<Renderer>().material.color = getColor(parts[1]);
        baseClothes.GetComponent<Renderer>().material.color = getColor(parts[2]);
        baseShoes.GetComponent<Renderer>().material.color = getColor(parts[3]);
    }

    public void transferToPlayer(){
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        PlayerController pc = player.GetComponent<PlayerController>();
        pc.parts = parts;
        pc.reload = true;
    }

    
}
