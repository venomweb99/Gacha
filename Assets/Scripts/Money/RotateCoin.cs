using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float m_RotateVelocity = 100f;

    private void Start()
    {
        MoveBeforeSpawn();
    }

    void Update()
    {
        // rotate horizontally
        transform.Rotate(Vector3.up * m_RotateVelocity * Time.deltaTime);
    }

    public void MoveBeforeSpawn()
    {
        //move horizontally and forward and back without
        float x = Random.Range(-2.5f,2.5f);
        float z = Random.Range(-1.6f, 0.1f);
        Vector3 move = new Vector3(x, 0.46f, z);
        transform.position += move;
    }
}
