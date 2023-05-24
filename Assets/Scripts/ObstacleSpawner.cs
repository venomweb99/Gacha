using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;

    private int likelyhood1 = 5;
    private int likelyhood2 = 85;
    private int likelyhood3 = 10;
    private int likelyhood4 = 0;
    private int likelyhood5 = 0;
    private int i = 0;
    private bool doing = false;
    // Start is called before the first frame update
    void Start()
    {
        likelyhood1 = 100 - likelyhood2 - likelyhood3 - likelyhood4 - likelyhood5;
        likelyhood2 = 100 - likelyhood1 - likelyhood3 - likelyhood4 - likelyhood5;
        likelyhood3 = 100 - likelyhood1 - likelyhood2 - likelyhood4 - likelyhood5;
        likelyhood4 = 100 - likelyhood1 - likelyhood2 - likelyhood3 - likelyhood5;
        likelyhood5 = 100 - likelyhood1 - likelyhood2 - likelyhood3 - likelyhood4;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!doing){
            doing = true;
            //check if the object has any children
            if(transform.childCount == 0){
                //if not, spawn one
                randomize();
            }
            else if(transform.childCount > 0){
                //if it does destroy all children
                foreach (Transform child in transform){
                    Destroy(child.gameObject);
                }
                //then spawn one
                randomize();
            }
        }
        
        
    }
    void randomize(){
        
        int random = Random.Range(0, 100);
            if (random <= likelyhood1)
            {
                var obs = Instantiate(prefab1, transform.position, Quaternion.identity);
                obs.transform.parent = transform;
                

                
            }
            else if (random <= likelyhood1 + likelyhood2 && random > likelyhood1)
            {
                var obs = Instantiate(prefab2, transform.position, Quaternion.identity);
                
                obs.transform.parent = transform;
            }
            else if (random <= likelyhood1 + likelyhood2 + likelyhood3 && random > likelyhood1 + likelyhood2)
            {
                var obs = Instantiate(prefab3, transform.position, Quaternion.identity);
                
                obs.transform.parent = transform;
            }
            else if (random <= likelyhood1 + likelyhood2 + likelyhood3 + likelyhood4 && random > likelyhood1 + likelyhood2 + likelyhood3){
                var obs = Instantiate(prefab4, transform.position, Quaternion.identity);
                
                obs.transform.parent = transform;
            }
            else if (random <= likelyhood1 + likelyhood2 + likelyhood3 + likelyhood4 + likelyhood5 && random > likelyhood1 + likelyhood2 + likelyhood3 + likelyhood4)
            {
                var obs = Instantiate(prefab5, transform.position, Quaternion.identity);
               
                obs.transform.parent = transform;
            }
    }
}


