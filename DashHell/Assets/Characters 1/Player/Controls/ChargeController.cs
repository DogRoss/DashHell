using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController : MonoBehaviour
{

    public GameObject playerObj;

    //public Transform tm;

    private void Start()
    {
        //tm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //tm = playerObj.transform;

        transform.position = playerObj.transform.position;

        Debug.Log(transform.position.x + " , " + transform.position.y);
    }
}
