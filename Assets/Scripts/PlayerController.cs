using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float margin = 2.0f;
    public float atkSpeed = 1.0f;
    public float dmg = 1.0f;
    public int level = 0;

    private float DatkSpeed = 1.0f;
    private float Ddmg = 1.0f;

    public GameObject baseHair;
    public GameObject baseSkin;
    public GameObject baseClothes;
    public GameObject baseShoes;
    public int weapon;
    public int hairColor;
    public int skinColor;
    public int clothesColor;
    public int shoesColor;

    public int[] parts = {1,2,1,3};
    public bool reload = false;


    
    // Start is called before the first frame update
    void Start()
    {
        setParts();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reload){
            setParts();
            reload = false;
        }
        //move the player to the z position of the mouse when the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, hit.point.z);
            }
        }

        //if the player is too far to the left or right, move them back to the edge of the screen
        if (transform.position.z < -margin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -margin);
        }
        else if (transform.position.z > margin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, margin);
        }
        
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
        hairColor = parts[0];
        skinColor = parts[1];
        clothesColor = parts[2];
        shoesColor = parts[3];
        if(hairColor>3){
            weapon = 1;
        }
        else{
            weapon = 0;
        }

        //set the color of the player parts based on the color variables
        baseHair.GetComponent<Renderer>().material.color = getColor(hairColor);
        baseSkin.GetComponent<Renderer>().material.color = getColor(skinColor);
        baseClothes.GetComponent<Renderer>().material.color = getColor(clothesColor);
        baseShoes.GetComponent<Renderer>().material.color = getColor(shoesColor);
    }
    public void gameOver(){
        //reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        resetStats();
    }

    void resetStats(){
        atkSpeed = DatkSpeed;
        dmg = Ddmg;
    }
}
