using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PitchControl : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject playerObject;
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {

        playerRB = playerObject.GetComponent<Rigidbody2D>();

        audioMixer.SetFloat("xAxisPitch", 0);
        audioMixer.SetFloat("yAxisPitch", 0);
        //audioMixer.SetFloat("xAxisVolume", 0.5f);
        //audioMixer.SetFloat("yAxisVolume", 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerRB.velocity.x > 0.1f)
        {
            //audioMixer. = Mathf.Abs(playerObject.GetComponent<Rigidbody2D>().velocity.x / 45);

            audioMixer.SetFloat("xAxisPitch", Mathf.Abs(playerObject.GetComponent<Rigidbody2D>().velocity.x / 60));
            //audioMixer.;
        }
        if (playerRB.velocity.x < -0.1f)
        {
            audioMixer.SetFloat("xAxisPitch", Mathf.Abs(playerObject.GetComponent<Rigidbody2D>().velocity.x / 60));
        }

        //xAxis^^
        //yAxisvv
        if (playerRB.velocity.y > 0.1f)
        {
            audioMixer.SetFloat("yAxisPitch", (Mathf.Abs(playerObject.GetComponent<Rigidbody2D>().velocity.y / 60)));
        }
        if (playerRB.velocity.y < -0.1f)
        {
            audioMixer.SetFloat("yAxisPitch", Mathf.Abs(playerObject.GetComponent<Rigidbody2D>().velocity.y / 60));
        }
        
    }
    //public void UpdatePitch(float newLevel)
    //{
    //    audioMixer.SetFloat("xAxisVolume", newLevel);
    //    audioMixer.SetFloat("yAxisVolume", newLevel);
    //}

}
