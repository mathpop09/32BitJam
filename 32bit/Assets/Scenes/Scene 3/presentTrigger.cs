using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presentTrigger : MonoBehaviour
{
    public bool startTet = false;
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
        this.GetComponent<SpriteRenderer>().enabled = false;
        startTet = true;
    }
}
