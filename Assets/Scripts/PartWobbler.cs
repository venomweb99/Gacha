using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartWobbler : MonoBehaviour
{
    private float wobbleSpeed = 12.0f;
    public float wobbleAmount = 0.0003f;
    public bool m_actve = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_actve == true)
        {
            //make the object move in the y axis
            transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount), transform.position.z);
        }

    }
}
