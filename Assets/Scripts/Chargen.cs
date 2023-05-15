using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chargen : MonoBehaviour
{
    public GameObject baseHair;
    public GameObject baseSkin;
    public GameObject baseClothes;
    public GameObject baseShoes;
    public int weapon;
    public int hairColor;
    public int skinColor;
    public int clothesColor;
    public int shoesColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createSeeded(int h, int s, int c, int sh, int w){
        hairColor = h;
        skinColor = s;
        clothesColor = c;
        shoesColor = sh;
        weapon = w;
    }

    void createRandom(){
        hairColor = Random.Range(0, 6);
        skinColor = Random.Range(0, 6);
        clothesColor = Random.Range(0, 6);
        shoesColor = Random.Range(0, 6);
        weapon = Random.Range(0, 6);
    }

    Color getColor(int color){
        switch(color){
            case 0:
                return Color.red;
            case 1:
                return Color.green;
            case 2:
                return Color.blue;
            case 3:
                return Color.yellow;
            case 4:
                return Color.magenta;
            case 5:
                return Color.cyan;

            default:
                return Color.white;
        }
    }

    void spawnParts(){
        //instantiate the gameobject parts as children of the character
        //set the color of the parts
        var hp = Instantiate(baseHair, transform.position, Quaternion.identity);
                hp.transform.parent = transform;
        var sp = Instantiate(baseSkin, transform.position, Quaternion.identity);
                sp.transform.parent = transform;
        var cp = Instantiate(baseClothes, transform.position, Quaternion.identity);
                cp.transform.parent = transform;
        var shp = Instantiate(baseShoes, transform.position, Quaternion.identity);
                shp.transform.parent = transform;

                

        baseHair.GetComponent<SpriteRenderer>().color = getColor(hairColor);
        baseSkin.GetComponent<SpriteRenderer>().color = getColor(skinColor);
        baseClothes.GetComponent<SpriteRenderer>().color = getColor(clothesColor);
        baseShoes.GetComponent<SpriteRenderer>().color = getColor(shoesColor);
    }
}
