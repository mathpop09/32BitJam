using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpPower = 7.5f;
    public float speed = 0.1f;
    private Vector3 RightRot;
    private Vector3 LeftRot;
    private bool turnRightMode = true; 
    public int turnSpeed = 1;

    bool grounded = false;
    Collider groundCollider;
    public AudioClip jumpSound;
    AudioSource audioPlayer;

    public bool moveable = true;
    public float disableLength;
    private float disableTimer;

    public GameObject spawnPoint;

    private bool dead = false;
    public AudioClip deathSound;
    public Sprite deathSprite;
   // Start is called before the first frame update

    
    void Start()
    {
        RightRot = this.transform.localRotation.eulerAngles;
        LeftRot = RightRot + new Vector3(0, 180, 0);

        audioPlayer = this.GetComponent<AudioSource>();
        groundCollider = this.GetComponent<BoxCollider>();

        this.transform.position = spawnPoint.transform.position;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (this.GetComponent<Rigidbody>().velocity.y <= -20)
        {
            Vector3 theVelocity = this.GetComponent<Rigidbody>().velocity;
            this.GetComponent<Rigidbody>().velocity = new Vector3(theVelocity.x, -20.0f, theVelocity.z);
        }
        if (!moveable)
        {
            disableTimer += Time.deltaTime;
            if (disableTimer >= disableLength)
            {
                if (dead == true)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                }
                moveable = true;
            }
        }
        else
        {
            // Jump
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
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (moveable)
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
        if (groundCollider.gameObject.tag == "rising platform" && grounded == true)
        {
            transform.parent = null;
        }
    }
    private void OnTriggerEnter(Collider groundCollider)
    {
        if (groundCollider.gameObject.tag != "smashTrigger")
            grounded = true;
        
        if (dead == false && groundCollider.gameObject.tag == "smashTrigger" && grounded == true)
        {
            dead = true;
            moveable = false;
            audioPlayer.clip = deathSound;
            audioPlayer.Play();
            disableTimer = 2.0f;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (dead == false && collision.gameObject.tag == "Enemy")
        {
            dead = true;
            moveable = false;
            audioPlayer.clip = deathSound;
            audioPlayer.Play();
            disableTimer = 2.0f;
            this.GetComponent<SpriteRenderer>().sprite = deathSprite;
        }
    }
    private void OnTriggerStay(Collider groundCollider)
    {
        if (groundCollider.gameObject.tag == "rising platform")
        {
            Debug.Log("chungus");
            transform.parent = groundCollider.gameObject.transform;
        }
        else
        {
            //transform.parent = null;
        }
        grounded = true;
    }

   
}
