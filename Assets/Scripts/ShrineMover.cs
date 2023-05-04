using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineMover : MonoBehaviour
{
    public float speed = 10;
    public float distance = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if the castle is out of the screen
        if(!(transform.position.x - Camera.main.transform.position.x < distance))
        {
            //move the castle to the left
        transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
    }
}
