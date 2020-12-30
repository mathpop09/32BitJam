using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toActivate : MonoBehaviour
{
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetComponent<riseTrigger>().rising == true)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
