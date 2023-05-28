using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargenGacha : MonoBehaviour
{
     public GameObject baseHair;
    public GameObject baseSkin;
    public GameObject baseClothes;
    public GameObject baseShoes;
    public int[] parts;
    public int weapon;
    public float atkSpeed = 2.0f;
    public float dmg = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
    
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
        switch(color){
            case 0:
                return new Color(0.8f, 0.4f, 0.2f);

            case 1:
                return new Color(1, 0.9f, 0.5f);
            case 2:
                return new Color(1, 0.8f, 0.6f);
            case 3:
                return new Color(0.7f, 0.7f, 0.4f);
            case 4:
                return new Color(0.6f, 0.5f, 0.4f);
            case 5:
                return new Color(0.9f, 0.9f, 1);
            case 6:
                return new Color(0.5f, 0.4f, 0.3f);

            default:
                return Color.white;
        }
    }

    void setParts(){

        //set the color of the player parts based on the color variables
        baseHair.GetComponent<Renderer>().material.color = getColor(parts[0]);
        baseSkin.GetComponent<Renderer>().material.color = getColor(parts[1]);
        baseClothes.GetComponent<Renderer>().material.color = getColor(parts[2]);
        baseShoes.GetComponent<Renderer>().material.color = getColor(parts[3]);
    }

    void transferToPlayer(){
        GameObject player = GameObject.Find("Player");
        PlayerController pc = player.GetComponent<PlayerController>();
        pc.parts = parts;
        pc.reload = true;
    }
}
