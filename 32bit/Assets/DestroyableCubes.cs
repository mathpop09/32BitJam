using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableCubes : MonoBehaviour
{
    private Vector3 originalPos;
    private bool destructionActivated = false;
    public float destructionTime = 2.0f;
    private float destructionTimer = 0.0f;

    public float blinkFrequency = 0.2f;
    public float blinkTimer = 0.0f;

    public Material aliveMat;
    public Material deadMat;
    private MeshRenderer thisTexture;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = this.transform.position;
        thisTexture = this.GetComponent<MeshRenderer>(); 
        thisTexture.material = aliveMat;
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (destructionActivated == true)
        {
            blinkTimer += Time.deltaTime;
            destructionTimer += Time.deltaTime;
            if (blinkTimer >= blinkFrequency)
            {
                this.enabled = !this.enabled;
                blinkTimer = 0.0f; 
            }

            if (destructionTimer >= destructionTime)
            {
                Destroy(this);
            }
        }
        //else if ((this.transform.position - originalPos).magnitude > 0.5f)
    }

    private void OnCollisionStay (Collision collision)
    {
        Debug.Log("ZUCK");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("ZUCK");
            destructionActivated = true;
            destroyBlock();
        }
    }
    //destroys block's collsion
    void destroyBlock()
    {
        thisTexture.material = deadMat;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;

        Destroy(this.GetComponent<BoxCollider>());
    }
}
