using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTilter : MonoBehaviour
{
    public float tiltAmount = 0.5f;
    public float tiltSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the object to make it wobble on the x axis
        transform.rotation = Quaternion.Euler(Mathf.Sin(Time.time * tiltSpeed) * tiltAmount, 0, 0);

        
        
    }
}
