using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 RightRot;
    private Vector3 LeftRot;
    private bool turnRightMode = true; 
    public int turnSpeed = 1;

    bool grounded = false;
    Collider groundCollider; 
    // Start is called before the first frame update
    void Start()
    {
        RightRot = this.transform.localRotation.eulerAngles;
        LeftRot = RightRot + new Vector3(0, 180, 0);

        groundCollider = this.GetComponent<BoxCollider>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (turnRightMode == false && (Quaternion.Angle(transform.localRotation, Quaternion.Euler(LeftRot))) > 0.0000001)
        {
            this.transform.localEulerAngles -= new Vector3(0, turnSpeed, 0);
        }
        else if (turnRightMode == true && (Quaternion.Angle(transform.localRotation, Quaternion.Euler(RightRot))) > 0.0000001)
        {
            this.transform.localEulerAngles += new Vector3(0, turnSpeed, 0);
        }
        // Jump
        Debug.Log(grounded);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Jump");
            if (grounded == true) {
                Jump();
                Debug.Log("Jumped");
            }
        }

        //Vertical Movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            WalkLeft();
            Debug.Log("Left");
            turnRightMode = false;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            WalkRight();
            Debug.Log("Right");
            turnRightMode = true; 
        }
    }

    void WalkRight()
    {
        this.transform.position += new Vector3 (speed, 0.0f, 0.0f); 
    }

    void WalkLeft()
    {
        this.transform.position -= new Vector3(speed, 0.0f, 0.0f);
    }

    void Jump()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 5.0f, 0.0f); 
    }

    private void OnTriggerExit(Collider groundCollider)
    {
        grounded = false; 
    }

    private void OnTriggerStay(Collider groundCollider)
    {
        grounded = true;
    }
}
