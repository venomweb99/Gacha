using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castlemover : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the castle to the left
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = speed * newSpeed;
    }
}
