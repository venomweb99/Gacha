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
        if(player.tag == "Player"){
            updatePlayer();
        }else{
            updateChargen();
        }
        
        
    }

    void updatePlayer(){
        if(timer > 3 - player.GetComponent<PlayerController>().atkSpeed){
            timer = 0.0f;
            if(done==false){
                done = true;
                checkWeapon();
                
            }
            if(isRanged){
                GameObject attack = Instantiate(attackRangePrefab, transform.position, Quaternion.identity);
                attack.GetComponent<Damager>().damage = player.GetComponent<PlayerController>().dmg * dmgMult;
                Destroy(attack, duration);
                
            }else{
                GameObject attack = Instantiate(attackPrefab, transform.position, Quaternion.identity);
                attack.transform.parent = transform;
                //get the attack script and set its damage
                attack.GetComponent<Damager>().damage = player.GetComponent<PlayerController>().dmg * dmgMult;
                Destroy(attack, duration);
            }
        }
    }

    void updateChargen(){
        if(timer > 3 - player.GetComponent<Chargen>().atkSpeed){
            timer = 0.0f;
            if(done==false){
                done = true;
                checkWeaponC();
                
            }
            if(isRanged){
                GameObject attack = Instantiate(attackRangePrefab, transform.position+ new Vector3(-1,0,0), Quaternion.identity);
                attack.GetComponent<Damager>().damage = player.GetComponent<Chargen>().dmg;
                Destroy(attack, duration);
                
            }else{
                GameObject attack = Instantiate(attackPrefab, transform.position, Quaternion.identity);
                attack.transform.parent = transform;
                //get the attack script and set its damage
                attack.GetComponent<Damager>().damage = player.GetComponent<Chargen>().dmg;
                Destroy(attack, duration);
            }
        }
    }

    void checkWeapon(){
        if(player.GetComponent<PlayerController>().weapon == 0){
            isRanged = false;
        }
        else{
            isRanged = true;
        }
    }
    void checkWeaponC(){
        if(player.GetComponent<Chargen>().weapon == 0){
            isRanged = false;
            duration /= 4;
        }
        else{
            isRanged = true;
            dmgMult = 0.5f;
        }
    }

    
}
