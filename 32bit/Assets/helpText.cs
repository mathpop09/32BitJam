﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpText : MonoBehaviour
{
    public GameObject textHold;
    public GameObject actualText;

    private float visibilityTime = 5.0f;
    private float timer = 0.0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        if (timer > visibilityTime)
        {
            textHold.SetActive(false); 
            actualText.SetActive(false);
        }
    }
}
