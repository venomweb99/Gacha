using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffGen : MonoBehaviour
{
    private GameObject player;
    private Color buffColor = new Color(1.0f, 0.8f, 0f);
    private Color debuffColor = new Color(.3f, 0.3f, 0.3f);
    private Color buffTextColor = new Color(1, 1, 1);
    private Color debuffTextColor = new Color(1, 1, 1);
    public float amount;
    private bool isDebuff;
    private int stat;
    public int amountMultiplier = 100;
    public int maxStat = 2;
    private float alarm = 0;
    private GameObject annex;
    private float textSize = 1.9f;
    private bool startAlarm = false;
    private bool once = false;
    private int prefabdefaultchildren = 2;
    void Start()
    {
        player = GameObject.Find("PlayerPrefab");
        
        randomizer();
        findAnnex();
        

    }
    void Update()
    {
        if(!once){
            once = true;
                makeText();
        }
        if (isDebuff)
        {
            GetComponent<Renderer>().material.color = debuffColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = buffColor;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            Destroy(annex);
            switch (stat)
            {
                case 0:
                    player.GetComponent<PlayerController>().dmg += amount;
                    break;
                case 1:
                    player.GetComponent<PlayerController>().atkSpeed += amount;
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
            
        }
    }

    void randomizer(){
        isDebuff = Random.Range(0, 2) == 0;
        stat = Random.Range(0, maxStat);
        amount = Random.Range(0.1f, 0.5f);
        if(isDebuff)
        {
            amount *= -1;
        }
        
    }

    void makeText(){

        Debug.Log("making text");
        if (this.transform.childCount == prefabdefaultchildren)
        {
            GameObject buffText = new GameObject();
                    buffText.transform.parent = transform;
                    buffText.transform.localPosition = new Vector3(4, 0, 5f);

                    buffText.AddComponent<TextMesh>();
                    buffText.transform.eulerAngles = new Vector3(170, -90, 180);

                    buffText.transform.localScale = new Vector3(textSize, textSize, textSize);

            int tempAmount = (int)(amount * amountMultiplier);

            switch (stat)
                {
                    case 0:
                        if(isDebuff)
                        {
                            buffText.GetComponent<TextMesh>().text = "ATK " + tempAmount;
                            buffText.GetComponent<TextMesh>().color = debuffTextColor;
                        }
                        else
                        {
                            buffText.GetComponent<TextMesh>().text = "ATK +" + tempAmount;
                            buffText.GetComponent<TextMesh>().color = buffTextColor;
                        }

                        break;
                    case 1:
                        if (isDebuff)
                        {
                            buffText.GetComponent<TextMesh>().text = "SPD " + tempAmount;
                            buffText.GetComponent<TextMesh>().color = debuffTextColor;
                        }
                        else
                        {
                            buffText.GetComponent<TextMesh>().text = "SPD +" + tempAmount;
                            buffText.GetComponent<TextMesh>().color = buffTextColor;
                        }
                        break;
                    default:
                        break;
                }
        }
    }

    void findAnnex(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Buff")
            {
                annex = hit.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit))
        {
            if (hit.collider.gameObject.tag == "Buff")
            {
                annex = hit.collider.gameObject;
            }
        }
    }
    
   
}
