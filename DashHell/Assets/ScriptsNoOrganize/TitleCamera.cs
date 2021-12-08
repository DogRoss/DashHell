using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    // Start is called before the first frame update

    bool canRotate = false;
    bool rotated = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        //before this happens, the initial animation needs to happen, execute this in script
        if(canRotate == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(90, 0, 0), Time.deltaTime);
            rotated = true;
        }

        if (rotated == true)
        {
            //start the portal sequence
        }
    }

    public void Rotate()
    {
        canRotate = true;
    }
}
