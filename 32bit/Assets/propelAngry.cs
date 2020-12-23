using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propelAngry : MonoBehaviour
{
    public float moveSpeed = 1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3 (moveSpeed, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(moveSpeed, 0.0f, 0.0f);
    }
}
