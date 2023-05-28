using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTilter : MonoBehaviour
{
    public float tiltAmount = 0.5f;
    public float tiltSpeed = 0.5f;
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
            float rot = Mathf.Sin(Time.time * tiltSpeed) * tiltAmount;
            transform.rotation = Quaternion.Euler(65, -90 + rot, 0);
        }
    }
}
