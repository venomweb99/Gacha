using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float HP = 3.0f;
    public GameObject son;
    private float maxHP;
    public GameObject player;
    
    private GManager m_GManager;

    public AudioClip m_GameOversound;
    public AudioClip m_RockDestroy;

    private void Start()
    {
        m_GManager = FindObjectOfType<GManager>();
    }

    //if player collides trigger gameover in it's script
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collided");
        //log other tag
        //Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            SoundManager.Instance.PlaySound(m_GameOversound);
            StartCoroutine(GameOver());
        }
        

    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        m_GManager.OpenPanelDead();
    }

    public void doDamage(float dmg){
        

        HP -= dmg;
        
        Material mat = son.GetComponent<Renderer>().material;
        if(HP < 3){
            Color a = new Color(1.0f, 0.8f, 0f);
            mat.color = a;
        }
        if(HP < 2){
            Color a = new Color(1.0f, 0.5f, 0f);
            mat.color = a;
        }
        if(HP < 1){
            Color a = new Color(1.0f, 0.2f, 0f);
            mat.color = a;
        }

        if(HP <= 0){
            SoundManager.Instance.PlaySound(m_RockDestroy);
            Destroy(gameObject);
        }

    }
}
