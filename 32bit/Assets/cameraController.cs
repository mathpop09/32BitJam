using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour
{

    private Vector3 playerInit;
    private Vector3 playerNow;
    public GameObject player;

    private Vector3 CameraInit;

    private void Start()
    {
        playerInit = player.transform.position;
        CameraInit = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        playerNow = player.transform.position;
        Vector3 Move = playerInit - playerNow;
        transform.position = CameraInit - Move; 
    }
}