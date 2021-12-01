using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Charge : MonoBehaviour
{
    static public Slider slider;
    static public float currentCharge = 700f;
    float maxCharge = 1000f;

    static public bool infCharge = false;

    static public void ReduceCharge()
    {
        if (!infCharge)
        {
            Charge.currentCharge-= 10f * Time.deltaTime; //time.deltatime accounts for update speed (fps) 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>(); //assumes script is on stamina bar

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentCharge / maxCharge;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReplenishStamina();
        }

    }

    
    public void ReplenishStamina()
    {
        currentCharge += 5f;
        
    }
}
