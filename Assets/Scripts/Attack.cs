using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float timer = 0.0f;
    public GameObject player;
    public GameObject attackPrefab;
    public GameObject attackRangePrefab;
    public bool isTriggered = false;
    private float duration = 0.6f;
    public bool isRanged = false;
    private float dmgMult = 1.0f;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer > 3 - player.GetComponent<PlayerController>().atkSpeed){
            timer = 0.0f;
            if(done==false){
                done = true;
                checkWeapon();
                
            }
            if(isRanged){
                GameObject attack = Instantiate(attackRangePrefab, transform.position, Quaternion.identity);
                Destroy(attack, duration);
                
            }else{
                GameObject attack = Instantiate(attackPrefab, transform.position, Quaternion.identity);
                attack.transform.parent = transform;
                Destroy(attack, duration);
            }
            
            //destoy the attack after 5 seconds
            


        }
        
    }

    void checkWeapon(){
        if(player.GetComponent<PlayerController>().weapon == 0){
            isRanged = false;
            duration /= 4;
        }
        else{
            isRanged = true;
            dmgMult = 0.5f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if(timer<duration){
            if(other.gameObject.tag == "Obstacle"){
                other.gameObject.GetComponent<Obstacle>().doDamage(player.GetComponent<PlayerController>().dmg * dmgMult);
            }
        }
    }
}
