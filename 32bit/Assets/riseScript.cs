using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riseScript : MonoBehaviour
{
    public GameObject lavaRiseTrigger;
    public float riseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lavaRiseTrigger.GetComponent<riseTrigger>().rising == true && transform.position.y < -42)
        {
            transform.position += new Vector3(0.0f, riseSpeed, 0.0f);
        }
    }


}
