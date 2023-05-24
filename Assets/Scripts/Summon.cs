using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            //instatiate prefab
            Instantiate(prefab, new Vector3(-1, 0, 0), Quaternion.identity);
            prefab.GetComponent<Chargen>().createRandom();
            //set as child of player
            prefab.transform.parent = other.gameObject.transform;
            Debug.Log("Summoned");


        }
    }
}
