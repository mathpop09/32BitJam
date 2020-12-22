using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float jumpPower = 7.5f;
    public float speed = 0.1f;
    private Vector3 RightRot;
    private Vector3 LeftRot;
    private bool turnRightMode = true; 
    public int turnSpeed = 1;

    bool grounded = false;
    Collider groundCollider;
    public AudioClip jumpSound;
    AudioSource audioPlayer;
   // Start is called before the first frame update

    
    void Start()
    {
        RightRot = this.transform.localRotation.eulerAngles;
        LeftRot = RightRot + new Vector3(0, 180, 0);

        audioPlayer = this.GetComponent<AudioSource>();
        groundCollider = this.GetComponent<BoxCollider>();
    }
    
    void Update()
    {
        // Jump
        Debug.Log(grounded);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Jump");
            if (grounded == true)
            {
                Jump();
                Debug.Log("Jumped");
            }
        }
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
        audioPlayer.clip = jumpSound;
        audioPlayer.Play();
        Debug.Log("played");
        this.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, jumpPower, 0.0f);
        
    }

    private void OnTriggerExit(Collider groundCollider)
    {
        grounded = false; 
    }
    private void OnTriggerEnter(Collider groundCollider)
    {
        grounded = true;
    }
    private void OnTriggerStay(Collider groundCollider)
    {
        grounded = true;
    }

   
}
