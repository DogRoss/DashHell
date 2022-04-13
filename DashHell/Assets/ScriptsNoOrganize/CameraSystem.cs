using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraSystem : MonoBehaviour
{

    public Volume ppVolume;
    public VolumeProfile ppProfile;
    //public PostProcessVolume ppVolume;
    public LensDistortion lensDistortionLayer;
    public Bloom test;

    //FloatParameter floatPam;

    public GameObject cameraObject;
    public GameObject playerObject;
    Vector3 playerPos;

    Rigidbody2D playerRB;

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

        lensDistortionLayer.xMultiplier.value = Mathf.Abs(playerObject.GetComponent<Rigidbody2D>().velocity.x / 45);
        lensDistortionLayer.yMultiplier.value = Mathf.Abs(playerObject.GetComponent<Rigidbody2D>().velocity.y / 45);
        //lensDistortionLayer.intensityX.value = Mathf.Lerp(Mathf.Abs());
        //lensDistortionLayer.intensityY.value = 1;


        //cameraObject.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.time * speed);
        playerPos = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, -20);
        cameraObject.transform.position = playerPos;

       // from.rotation = cameraObject.transform.rotation;

        
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

    void SetUpPP()
    {
        ppProfile = ppVolume.sharedProfile;
        ppProfile.TryGet(out lensDistortionLayer);

        lensDistortionLayer.xMultiplier.value = 0;
        lensDistortionLayer.yMultiplier.value = 0;
        //lensDistortionLayer.intensity = new FloatParameter();
    }
}
