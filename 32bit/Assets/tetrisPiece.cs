using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrisPiece : MonoBehaviour
{
    public int dropOrder;
    private Vector3 InitialPosition;
    private MeshRenderer[] childRenderers;
    private Transform[] childTransforms;
    private bool notVisible = true;
    //timer check for when the piece starts moving;
    private float waitTime;
    private float waitTimer = 0.0f;
    //timer check for each unit of distance where the piece moves
    private float timerUnit = 0.5f;
    private float timerMove;
    // Start is called before the first frame update

    private AudioSource pieceAudio;
    bool soundPitchUp = false;
    void Start()
    {
        pieceAudio = this.GetComponent<AudioSource>();

        InitialPosition = transform.position;
        transform.position += new Vector3(0.0f, 24.0f, 0.0f);
        //childRenderers = this.GetComponentInChildren<MeshRenderer>();
        childTransforms = GetComponentsInChildren<Transform>();
        childRenderers = GetComponentsInChildren<MeshRenderer>();
        childRenderers[0].enabled = false;
        childRenderers[1].enabled = false;
        childRenderers[2].enabled = false;
        childRenderers[3].enabled = false; 

        waitTime = dropOrder * 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //make sprite visible below a certain position
        if (waitTimer >= waitTime)
        {
            if (notVisible == true) 
                makeVisible();

            movePiece();
        }
        else
        {
            waitTimer += Time.deltaTime;
        }
    }

    void makeVisible()
    {
        childRenderers[0].enabled = true;
        childRenderers[1].enabled = true;
        childRenderers[2].enabled = true;
        childRenderers[3].enabled = true;
        notVisible = false;
    }

    void movePiece()
    {
        if (InitialPosition.y + 0.01 <= this.transform.position.y)
        {
            timerMove += Time.deltaTime;
            if (timerMove >= timerUnit)
            {
                if (soundPitchUp == false)
                {
                    soundPitchUp = true;
                    pieceAudio.pitch += 0.1f;
                }
                else
                {
                    soundPitchUp = false;
                    pieceAudio.pitch -= 0.1f;
                }
                pieceAudio.Play();
                timerMove = 0;
                this.transform.position -= new Vector3(0.0f, 2.0f, 0.0f);
            }
        }
    }
}
