using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorToParents : MonoBehaviour
{
    // Start is called before the first frame update
    private float alarm = 0;
    private float loadTime = 0.5f;
    private bool done = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alarm += Time.deltaTime;
        if(alarm >= loadTime && done ==false)
        {
            done = true;
            //set the light color to it's parent's color
            GetComponent<Light>().color = transform.parent.GetComponent<Renderer>().material.color;
            //get an average of the colors rgb values
            float avg = (GetComponent<Light>().color.r*0.1f + GetComponent<Light>().color.g * 0.6f + GetComponent<Light>().color.b *0.3f);
            //set the light intensity to the average
            GetComponent<Light>().intensity = 1-avg;


        }
    }
}
