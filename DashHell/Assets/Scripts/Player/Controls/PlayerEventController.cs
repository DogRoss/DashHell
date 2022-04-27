using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEventController : MonoBehaviour
{
    public GameObject startSpawn;

    Rigidbody2D rb;

    //menu
    [SerializeField]GameObject menuObject;
    [SerializeField]GameObject scoreObject;
    [SerializeField]GameObject timerObject;
    [SerializeField] Timer timer;

    //trigger and triggee objects
    public List<GameObject> effectedObjects = new List<GameObject>(); //effected items will always be setactive(false)
    public List<GameObject> causationObjects = new List<GameObject>();//causation items will always be setactive(true)public bool cheatsOn = false;

    public bool cheatsOn = false;
    GameObject passOverObject;
    DontDestroy dontDestroy;

    // Start is called before the first frame update
    void Start()
    {
        menuObject.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        if (GameObject.Find("PassOver"))
        {
            passOverObject = GameObject.Find("PassOver");
            dontDestroy = passOverObject.GetComponent<DontDestroy>();
            cheatsOn = dontDestroy.ReturnCheatState();
        }
        

        transform.position = startSpawn.transform.position; //spawnpoint set

        string causeTag;
        string effectTag;

        //sets up level objects
        foreach(GameObject causationObject in causationObjects)
        {
            causeTag = causationObject.tag;
            switch (causeTag)
            {
                case "LevelResetter":
                    causationObject.SetActive(false);
                    break;
                case "Trigger":
                    causationObject.SetActive(true);
                    break;
            }
        }
        foreach (GameObject effectedObject in effectedObjects)
        {
            effectTag = effectedObject.tag;
            switch (effectTag)
            {
                case "Finish":
                    effectedObject.SetActive(false);
                    break;
                case "LevelResetter":
                    effectedObject.SetActive(false);
                    break;
                case "Gate":
                    effectedObject.SetActive(false);
                    break;
                default:
                    effectedObject.SetActive(true);
                    break;
            }
        }
    }

    private void Triggered() //when the score trigger is hit, sets up the other part of the level
    {
        timer.ScoreUp();
        causationObjects[0].SetActive(false);

        string effectTag;
        foreach (GameObject objectToTrigger in effectedObjects)
        {
            effectTag = objectToTrigger.tag;
            switch (effectTag)
            {
                case "LevelResetter":
                    objectToTrigger.SetActive(true);
                    break;
                case "Finish":
                    objectToTrigger.SetActive(true);
                    break;
                case "ToBeTriggered":
                    objectToTrigger.SetActive(false);
                    break;
                case "Gate":
                    objectToTrigger.SetActive(true);
                    break;
            }
        }
    }

    private void Finished() //if win, go to main menu
    {
        SceneManager.LoadScene(0);
    }

    private void ResetLevel() //resets level at runtime whilst contiuing said level
    {
        foreach (GameObject causationObject in causationObjects)
        {
            causationObject.SetActive(true);
        }

        string effectTag;
        foreach (GameObject effectedObject in effectedObjects)
        {
            effectTag = effectedObject.tag;
            switch (effectTag)
            {
                case "Finish":
                    effectedObject.SetActive(false);
                    break;
                case "LevelResetter":
                    effectedObject.SetActive(false);
                    break;
                case "Gate":
                    effectedObject.SetActive(false);
                    break;
                default:
                    effectedObject.SetActive(true);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Damage")
        {
            timer.ResetScore();
        }
        if (other.tag == "Damage" || other.tag == "Gate" || other.tag == "ToBeTriggered" && !cheatsOn) //if you hit a wall
        {
            string causeTag;
            string effectTag;
            foreach (GameObject causationObject in causationObjects)
            {
                causeTag = causationObject.tag;
                switch (causeTag)
                {
                    case "Gate":
                        causationObject.SetActive(false);
                        break;
                    default:
                        causationObject.SetActive(true);
                        break;
                }
            }

            foreach (GameObject effectedObject in effectedObjects)
            {
                effectTag = effectedObject.tag;
                if (effectTag == "Finish" || effectTag == "LevelResetter" || effectTag == "Gate")
                {
                    effectedObject.SetActive(false);
                }
                else
                {
                    effectedObject.SetActive(true);
                }
            }

            //menu ui setup
            timer.StopTime();
            menuObject.SetActive(true);
            timerObject.transform.position = menuObject.transform.position + (Vector3.up * 200);
            scoreObject.transform.position = menuObject.transform.position + (Vector3.up * 150);
            
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }


        string triggerTag = other.tag;
        switch (triggerTag)
        {
            case "Trigger": //if score collider
                Triggered();
                break;
            case "Finish": //if win collider
                Finished();
                break;
            case "LevelResetter": //if level reset collider
                ResetLevel();
                break;
        }
    }
}
