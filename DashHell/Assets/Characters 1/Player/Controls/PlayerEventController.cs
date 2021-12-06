using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEventController : MonoBehaviour
{
    public GameObject startSpawn;

    //Transform setRespawn;

    Rigidbody2D rb;

    public List<GameObject> effectedObjects = new List<GameObject>();

    public List<GameObject> causationObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //setRespawn.position = startSpawn.transform.position; //spawnpoint set
        this.transform.position = startSpawn.transform.position; //spawnpoint set


    }

    private void Triggered()
    {
        causationObjects[0].SetActive(false);

        foreach (GameObject objectToTrigger in effectedObjects)
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
        //this.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {

        //foreach (GameObject objectToDisable in causationObjects)
        //{
        //    if (objectToDisable.transform.position.x <= 3 && objectToDisable.transform.position.y <= 3)//to make sure i dont just disable every single trigger
        //    {
        //        objectToDisable.SetActive(false);
        //    }
        //        
        //}

        

        if (other.tag == "Damage")
        {
            rb.velocity = new Vector2(0,0);
            this.transform.position = startSpawn.transform.position; //resets when player hits bad wall
        }

        if (other.CompareTag("Trigger")) //if its a regular trigger type
        {
            Triggered();
        }

        if (other.CompareTag("Finish")) //if the end goal was reached
        {
            Finished();
        }
        //V-for future addons like powerups-V
    }
}
