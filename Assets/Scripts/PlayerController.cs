using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float margin = 2.0f;
    public float atkSpeed = 1.0f;
    public float dmg = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the player to the z position of the mouse when the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, hit.point.z);
            }
        }

        //if the player is too far to the left or right, move them back to the edge of the screen
        if (transform.position.z < -margin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -margin);
        }
        else if (transform.position.z > margin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, margin);
        }
        
    }
}
