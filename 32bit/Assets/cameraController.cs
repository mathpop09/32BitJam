using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour
{

    private Vector3 playerInit;
    private Vector3 playerNow;
    public GameObject player;

    private Vector3 CameraInit;

    public float ShakeIntensity;
    private bool shaking = false;
    private Vector3 beforeShakePos;
    public float shakeDuration = 2.0f;
    private float time = 0.0f;

    private void Start()
    {
        playerInit = player.transform.position;
        CameraInit = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (shaking == true)
        {
            time += Time.deltaTime;
            transform.position = beforeShakePos + Random.insideUnitSphere * ShakeIntensity;
            if (shakeDuration <= time)
            {
                time = 0;
                shaking = false;
                transform.position = beforeShakePos;
            }
        }
        else
        {
            playerNow = player.transform.position;
            Vector3 Move = playerInit - playerNow;
            transform.position = CameraInit - Move;
        }
    }

    public void shake()
    {
        beforeShakePos = transform.position;
        shaking = true;
        this.GetComponent<AudioSource>().Play();
    }
}