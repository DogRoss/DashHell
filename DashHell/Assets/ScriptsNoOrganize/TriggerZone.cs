using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    //public GameObject objectTooTrigger;

    public List<GameObject> objectsToTrigger = new List<GameObject>();

    public List<GameObject> trigger = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Triggered()
    {
        //triggerCause.SetActive(false);


        foreach (GameObject objectToTrigger in objectsToTrigger)
        {
            if (objectToTrigger.activeSelf == true)
            {
                objectToTrigger.SetActive(false);
            }
            else
            {
                objectToTrigger.SetActive(true);
            }

        }
    }

    private void Finished()
    {



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        //try to make it so it can disable and re-enable with each touch
        if(other.CompareTag("Trigger")) //if its a regular trigger type
        {
            Triggered();
        }

        if(other.CompareTag("Finish")) //if the end goal was reached
        {
            Finished();
        }
        
    }
}
