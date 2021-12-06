using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject playerObject;

    public Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = this.transform.position;

        cameraPosition.x = playerObject.transform.position.x;
        cameraPosition.y = playerObject.transform.position.y;

        this.transform.position = cameraPosition;

    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = this.transform.position;

        cameraPosition.x = playerObject.transform.position.x;
        cameraPosition.y = playerObject.transform.position.y;

        this.transform.position = cameraPosition;
    }
}
