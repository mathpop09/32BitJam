using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrisPiece : MonoBehaviour
{
    public int dropOrder;
    private Vector3 InitialPosition;
    private MeshRenderer thisSprite;
    //timer check for when the piece starts moving;
    public float waitTime;
    private float waitTimer = 0.0f;
    //timer check for each unit of distance where the piece moves
    public float timerUnit;
    private float timerMove;
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
        transform.position += new Vector3(0.0f, 24.0f, 0.0f);
        thisSprite = this.GetComponent<MeshRenderer>();
        thisSprite.enabled = false;

        waitTime = dropOrder * 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //make sprite visible below a certain position
        makeVisible();
        if (waitTimer >= waitTime)
        {
            movePiece();
        }
        else
        {
            waitTimer += Time.deltaTime;
        }
    }

    void makeVisible()
    {
        if (InitialPosition.y <= 10)
        {
            thisSprite.enabled = true;
        }
    }

    void movePiece()
    {
        if (InitialPosition.y + 0.01 <= this.transform.position.y)
        {
            timerMove += Time.deltaTime;
            if (timerMove >= timerUnit)
            {
                timerMove = 0;
                this.transform.position -= new Vector3(0.0f, 2.0f, 0.0f);
            }
        }
    }
}
