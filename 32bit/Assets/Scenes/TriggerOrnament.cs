using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOrnament : MonoBehaviour
{
    public GameObject cameraToShake;
    public GameObject monster;
    public GameObject player;
    public GameObject InvisibleWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Go!");
        Destroy(InvisibleWall);
        this.GetComponent<SpriteRenderer>().enabled = false;
        cameraToShake.GetComponent<cameraController>().shake();
        monster.GetComponent<propelAngry>().startMove();
        player.GetComponent<PlayerMovement>().moveable = false;
        player.GetComponent<PlayerMovement>().disableLength = 3.0f;
        Destroy(this);
    }
}
