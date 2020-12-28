using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    private float bobLevel;


    private Vector3 ogPosition;
    // Start is called before the first frame update
    private bool goDown = true;
    private int increments = 0;
    private int maxIncs = 60;

    private bool started = false;
    private float bobStartTime;
    private float bobTimer = 0.0f;
    void Start()
    {
        ogPosition = this.transform.position;
        bobLevel = Random.Range(0.3f, 0.6f);
        bobStartTime = Random.Range(0.0f, 2.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (started == false)
        {
            bobTimer += Time.deltaTime;
            if (bobTimer >= bobStartTime)
            {
                started = true;
            }
        }
        if (started == true)
        {
            if (goDown == true && increments <= maxIncs)
            {
                this.transform.position -= new Vector3(0.0f, bobLevel / maxIncs, 0.0f);
                increments++;
            }
            else if (goDown == true)
            {
                increments = 0;
                goDown = false;
            }
            else if (goDown == false && increments <= maxIncs)
            {
                this.transform.position += new Vector3(0.0f, bobLevel / maxIncs, 0.0f);
                increments++;
            }
            else if (goDown == false)
            {
                increments = 0;
                goDown = true;
                bobLevel = Random.Range(0.1f, 0.5f);
            }
        }
    }
}
