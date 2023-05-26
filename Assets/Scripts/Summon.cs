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
            GameObject prefab1 = Instantiate(prefab, new Vector3(0, 1, 0), Quaternion.identity);
            prefab1.GetComponent<Chargen>().createRandom();
            //set as child of player
            prefab1.transform.parent = other.gameObject.transform;
            //set position to player
            float rand1 = Random.Range(-0.7f, 0.7f);
            float rand2 = Random.Range(-0.1f, -0.7f);
            prefab1.transform.position = other.gameObject.transform.position + new Vector3(rand2, 0, rand1);

            
            Debug.Log("Summoned");


        }
    }
}
