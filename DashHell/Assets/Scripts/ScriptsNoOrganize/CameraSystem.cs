using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraSystem : MonoBehaviour
{
    //post processing
    public Volume ppVolume;
    public VolumeProfile ppProfile;
    public LensDistortion lensDistortionLayer;
    public Bloom test;

    //player
    public GameObject cameraObject;
    public GameObject playerObject;
    Vector3 playerPos;
    Rigidbody2D playerRB;
    Vector3 playerVel = Vector3.zero;

    float rotationX;
    float rotationY;
    float rotationZ;

    float rotationMax = 10f;
    public float speed = 1f;

    //public GameObject cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        SetUpPP();

        playerRB = playerObject.GetComponent<Rigidbody2D>();

        playerPos = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, -20);
        cameraObject.transform.position = playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        //changes lens distortion based on movement
        playerVel = playerRB.velocity;
        lensDistortionLayer.xMultiplier.value = Mathf.Abs(playerVel.x / 45);
        lensDistortionLayer.yMultiplier.value = Mathf.Abs(playerVel.y / 45);

        //tracks camera to player
        playerPos = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, -20);
        cameraObject.transform.position = playerPos;

        //rotates camera dependant on input
        rotationX = playerRB.velocity.x;
        if (rotationX > 10) //rotates around y access (left right)
        {
            rotationX = 9;
        }
        else if (rotationX < -10)
        {
            rotationX = -9;
        }

        rotationY = -playerRB.velocity.y;
        if (rotationY > 10)//rotates around x access (up down)
        {
            rotationY = 9;
        }
        else if (rotationY < -10)//rotates around x access (up down)
        {
            rotationY = -9;
        }

        rotationZ = 0f;
        if (rotationZ > 10)
        {
            rotationZ = 10;
        }
        else if (rotationZ < -10)//rotates around x access (up down)
        {
            rotationZ = -9;
        }

        cameraObject.transform.rotation = Quaternion.Slerp(cameraObject.transform.rotation, Quaternion.Euler(rotationY, rotationX, rotationZ), Time.deltaTime * speed);
    }

    //setup for post processing
    void SetUpPP()
    {
        ppProfile = ppVolume.sharedProfile;
        ppProfile.TryGet(out lensDistortionLayer);

        lensDistortionLayer.xMultiplier.value = 0;
        lensDistortionLayer.yMultiplier.value = 0;
    }
}
