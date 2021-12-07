using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class CameraSystem : MonoBehaviour
{
    /*
    public GameObject playerObject;
    public Rigidbody2D playerRB;

    public GameObject cameraObject;

    Vector3 cameraPosition;

    Transform cameraTransform;

    private float TimeCount = 0.0f;

    

    //public GameObject cameraObject;

    public int interpolationFrameCount = 45;
    int elapsedFrames = 0;

    // Start is called before the first frame update
    void Start()
    {
        //cameraObject = GetComponent<GameObject>();
        //
        ////cameraPosition = this.transform.position;
        //cameraObject.transform.position = this.transform.position;
        playerRB = playerObject.GetComponent<Rigidbody2D>();

        cameraPosition.x = playerObject.transform.position.x;
        cameraPosition.y = playerObject.transform.position.y;
        cameraPosition.z = -20;

        cameraObject.transform.position = cameraPosition;

    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = this.transform.position;

        cameraPosition.x = playerObject.transform.position.x;
        cameraPosition.y = playerObject.transform.position.y;
        cameraPosition.z = -20;

        cameraObject.transform.position = cameraPosition;

        //this.transform.rotation = Quaternion.Euler(temp); //use this for rotation

        if (playerRB.velocity.x >= .1f) //right rotate
        {
            //first, set rotation vector to go right

            //float interpolationRatio = (float)elapsedFrames / interpolationFrameCount;

            cameraObject.transform.rotation = Quaternion.Slerp(cameraTransform.rotation,(Quaternion.Euler(0, 10, 0)), rightTimeCount);
            TimeCount += Time.deltaTime;



            //Vector3 temp = new Vector3(0, 10, 0);
            //this.transform.Rotate(Vector3.Lerp(this.transform.rotation, temp, ));
            
        }
        //else //left rotate
        //{
        //
        //}
        //
        //if (playerRB.velocity.y >= .1f) //up rotate
        //{
        //
        //}
        //else //down rotate
        //{
        //
        //}

    }
    */

    public PostProcessVolume ppVolume;
    LensDistortion lensDistortionLayer;
    Bloom _bloom;

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
        ppVolume.profile.TryGetSettings<LensDistortion>(out lensDistortionLayer);

        //.profile.TryGetSettings(out _bloom);

        lensDistortionLayer.intensityX.value = 0;
        lensDistortionLayer.intensityY.value = 0;
        //lensDistortionLayer.intensity = new FloatParameter();



        playerRB = playerObject.GetComponent<Rigidbody2D>();


        playerPos = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, -20);
        cameraObject.transform.position = playerPos;
    }

    // Update is called once per frame
    void Update()
    {

        lensDistortionLayer.intensityX.value = Mathf.Abs(playerObject.GetComponent<Rigidbody2D>().velocity.x / 45);
        lensDistortionLayer.intensityY.value = Mathf.Abs(playerObject.GetComponent<Rigidbody2D>().velocity.y / 45);
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
        //Time.time * (speed)



    }
}
