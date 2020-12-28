using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swayingLava : MonoBehaviour
{
    private Vector3 swayLevel;

    // Start is called before the first frame update
    private bool goDown = true;
    private int increments = 0;
    private int maxIncs = 60;
    // Start is called before the first frame update
    void Start()
    {
        swayLevel = Random.insideUnitSphere * 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goDown == true && increments <= maxIncs)
        {
            this.transform.position -= new Vector3(swayLevel.x / maxIncs, 0.0f, swayLevel.z / maxIncs);
            increments++;
        }
        else if (goDown == true)
        {
            increments = 0;
            goDown = false;
        }
        else if (goDown == false && increments <= maxIncs)
        {
            this.transform.position += new Vector3(swayLevel.x / maxIncs, 0.0f, swayLevel.z / maxIncs);
            increments++;
        }
        else if (goDown == false)
        {
            increments = 0;
            goDown = true;
            swayLevel = Random.insideUnitSphere * 2;
        }
    }
}
