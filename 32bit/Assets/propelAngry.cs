using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propelAngry : MonoBehaviour
{
    private float blastSpeed = 3.5f;
    public float moveSpeed = 1.0f;
    private float actualMove = 0.0f;
    private float time = 0.0f;
    public float lengthWait = 2.0f;
    private float speedWait = 3.3f;

    private bool startTimer = false;

    private bool startBlastTimer = false;

    private bool startReg = false;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3 (moveSpeed, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startTimer) {
            time += Time.deltaTime;
            if (lengthWait <= time)
            {
                //transform.position += new Vector3(actualMove, 0.0f, 0.0f);
                startBlastTimer = true;
                startTimer = false;
            }
        }
        else if (startBlastTimer)
        {
            time += Time.deltaTime;
            if (speedWait <= time)
            {
                startBlastTimer = false;
                transform.position += new Vector3(blastSpeed, 0.0f, 0.0f);
                startReg = true;
                this.GetComponent<AudioSource>().Play();
            }
        }
        else if (startReg == true)
        {
            transform.position += new Vector3(moveSpeed, 0.0f, 0.0f);
        }
    }

    public void startMove()
    {
        actualMove = moveSpeed;
        startTimer = true;
    }
}
