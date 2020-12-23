using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayerUp : MonoBehaviour
{
    bool moveStart = false;
    float playerStartZ;
    GameObject Player;
    public bool Direction;
    private int valueMultiplier;

    private AudioSource sounder;
    // Start is called before the first frame update
    void Start()
    {
        sounder = this.GetComponent<AudioSource>();
        if (Direction == true)
        {
            valueMultiplier = 1;
        }
        else
        {
            valueMultiplier = -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveStart == true)
        {
            if (Direction == true)
            {
                Player.transform.position += new Vector3(0.0f, 0.0f, 0.04f);
                if (Player.transform.position.z >= playerStartZ +  1.99f)
                {
                    moveStart = false;
                }
            }
            else
            {
                Player.transform.position -= new Vector3(0.0f, 0.0f, 0.04f);
                if (Player.transform.position.z <= playerStartZ - 1.99f)
                {
                    moveStart = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (moveStart == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                sounder.Play();
                Player = collision.gameObject;
                playerStartZ = Player.transform.position.z;
                moveStart = true; 
            }
        }
    }

}
