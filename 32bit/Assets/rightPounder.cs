using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightPounder : MonoBehaviour
{
    private Vector3 ogPosition;
    public float speed = 0.1f;
    private bool poundRight = true;
    // Start is called before the first frame update
    void Start()
    {
        ogPosition = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (poundRight == true)
            this.transform.position += new Vector3(speed, 0.0f, 0.0f);
        if (poundRight == false)
        {
            this.transform.position -= new Vector3(speed / 2, 0.0f, 0.0f);
            if (this.transform.position.x <= ogPosition.x)
            {
                this.transform.position = ogPosition;
                poundRight = true;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("cucky");

        if (poundRight == true)
        {
            Debug.Log("cucky");
            poundRight = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("cucky");

        if (poundRight == true)
        {
            Debug.Log("cucky");
            poundRight = false;
        }
    }
}

