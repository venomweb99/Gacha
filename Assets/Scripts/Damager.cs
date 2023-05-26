using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damage;
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
        //Debug.Log("collided");
        if(other.gameObject.tag == "Obstacle"){
                other.gameObject.GetComponent<Obstacle>().doDamage(damage);
        //Debug.Log("Damage dealt: " + damage);
        }
        
    }
}
