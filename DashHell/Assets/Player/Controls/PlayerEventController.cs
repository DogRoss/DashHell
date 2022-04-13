﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEventController : MonoBehaviour
{
    public GameObject startSpawn;

    Rigidbody2D rb;

    public List<GameObject> effectedObjects = new List<GameObject>(); //effected items will always be setactive(false)
    public List<GameObject> causationObjects = new List<GameObject>();//causation items will always be setactive(true)public bool cheatsOn = false;

    public bool cheatsOn = false;
    GameObject passOverObject;
    DontDestroy dontDestroy;


    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        if (GameObject.Find("PassOver"))
        {
            passOverObject = GameObject.Find("PassOver");
            dontDestroy = passOverObject.GetComponent<DontDestroy>();
            cheatsOn = dontDestroy.ReturnCheatState();
        }
        

        //setRespawn.position = startSpawn.transform.position; //spawnpoint set
        this.transform.position = startSpawn.transform.position; //spawnpoint set

        foreach(GameObject causationObject in causationObjects)
        {
            if (causationObject.CompareTag("LevelResetter")) //for resetting level
            {
                causationObject.SetActive(false);
            }
            else if (causationObject.CompareTag("Trigger")) //activates opening to next level
            {
                causationObject.SetActive(true);
            }

            
        }

        //foreach (GameObject effectedObject in effectedObjects)
        for (int i = 0; i < effectedObjects.Capacity; i++)
        {
            if (effectedObjects[i].CompareTag("Finish") || effectedObjects[i].CompareTag("LevelResetter"))
            {
                effectedObjects[i].SetActive(false);
            }
            else
            {
                effectedObjects[i].SetActive(true);
            }
        }
    }

    private void Triggered()
    {
        causationObjects[0].SetActive(false);

        foreach (GameObject objectToTrigger in effectedObjects)
        {
            if (objectToTrigger.CompareTag("LevelResetter") || objectToTrigger.CompareTag("Finish")) //for resetting level
            {
                objectToTrigger.SetActive(true);
            }
            else if (objectToTrigger.CompareTag("ToBeTriggered")) //activates opening to next level
            {
                objectToTrigger.SetActive(false);
            }


        }
    }

    private void Finished()
    {
        SceneManager.LoadScene(0);
    }

    private void ResetLevel()
    {
        foreach (GameObject causationObject in causationObjects)
        {
            causationObject.SetActive(true);
        }

        foreach (GameObject effectedObject in effectedObjects)
        {
            if (effectedObject.CompareTag("Finish") || effectedObject.CompareTag("LevelResetter"))
            {
                effectedObject.SetActive(false);
            }
            else
            {
                effectedObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Damage" || other.tag == "ToBeTriggered" && !cheatsOn)
        {
            foreach (GameObject causationObject in causationObjects)
            {
                causationObject.SetActive(true);
            }

            foreach (GameObject effectedObject in effectedObjects)
            {
                if (effectedObject.CompareTag("Finish") || effectedObject.CompareTag("LevelResetter"))
                {
                    effectedObject.SetActive(false);
                }
                else
                {
                    effectedObject.SetActive(true);
                }
            }
            rb.velocity = new Vector2(0, 0);
            transform.position = startSpawn.transform.position; //resets when player hits bad wall

        }

        if (other.CompareTag("Trigger")) //if its a regular trigger type
        {
            Triggered();
        }

        if (other.CompareTag("Finish")) //if the end goal was reached
        {
            Finished();
        }

        if (other.CompareTag("LevelResetter"))
        {
            ResetLevel();
        }
        //V-for future addons like powerups-V
    }
}