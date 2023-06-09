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

    public GameObject m_Legs;
    public GameObject m_Body;
    public GameObject m_Hands;
    public GameObject m_Hair;


    // Start is called before the first frame update
    void Start()
    {
        LoadParts();
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
            reload = true;
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


    public void PauseMovememnt(bool pause)
    {
        if (pause)
        {
            m_Legs.GetComponent<PartTilter>().m_actve = true;
            m_Body.GetComponent<PartTilter>().m_actve = true;
            m_Hands.GetComponent<PartWobbler>().m_actve = true;
            m_Hair.GetComponent<PartTilter>().m_actve = true;
            m_Hair.GetComponent<PartWobbler>().m_actve = true;
        }
        else
        {
            m_Legs.GetComponent<PartTilter>().m_actve = false;
            m_Body.GetComponent<PartTilter>().m_actve = false;
            m_Hands.GetComponent<PartWobbler>().m_actve = false;
            m_Hair.GetComponent<PartTilter>().m_actve = false;
            m_Hair.GetComponent<PartWobbler>().m_actve = false;
        }
    }
    public Color getColor(int color){
        switch(color){
            case 0:
                return new Color(1f, 0.9f, 0.0f);
            case 1:
                return new Color(1, 0.9f, 0.5f);
            case 2:
                return new Color(1, 0.8f, 0.6f);
            case 3:
                return new Color(0.5f, 0.4f, 0.3f);
            case 4:
                return new Color(0.3f, 0.7f, 1f);
            case 5:
                return new Color(1f, 0.3f, 0.3f);
            case 6:
                return new Color(0.8f, 1f, 0.6f);

            default:
                return Color.white;
        }
    }

    void setParts(){
        Debug.Log("setting parts ... Hair color:" + parts[0]);
        hairColor = parts[0];
        skinColor = parts[1];
        clothesColor = parts[2];
        shoesColor = parts[3];
        weapon = 1;

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
    public void SaveParts()
    {
        Debug.Log("Saved PARTS.");
        PlayerPrefs.SetInt("PlayerHair", parts[0]);
        PlayerPrefs.SetInt("PlayerSkin", parts[1]);
        PlayerPrefs.SetInt("PlayerClothes", parts[2]);
        PlayerPrefs.SetInt("PlayerShoes", parts[3]);
        PlayerPrefs.Save();
    }

    public void LoadParts()
    {
        //check if the key exists
        if (PlayerPrefs.HasKey("PlayerHair"))
        {
            Debug.Log("Loaded PARTS.");
            parts[0] = PlayerPrefs.GetInt("PlayerHair");
            parts[1] = PlayerPrefs.GetInt("PlayerSkin");
            parts[2] = PlayerPrefs.GetInt("PlayerClothes");
            parts[3] = PlayerPrefs.GetInt("PlayerShoes");
        }
    }
}
