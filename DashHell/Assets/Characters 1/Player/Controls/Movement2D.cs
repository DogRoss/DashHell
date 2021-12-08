using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    Vector2 deacceleration = new Vector2(1,1);

    InputAction input;
    InputActionMap inputMap;
    InputActionAsset inputAsset;
    PlayerInput playerInput;

    float maxSpeed = 50f;


    float chargeAddValue = .2f;
    
    float chargeMax = 20f;

    Vector2 charge;

    float chargeValueUp = 1f;
    float chargeValueDown = 1f;
    float chargeValueLeft = 1f;
    float chargeValueRight = 1f;

    

    //Vector2 chargeMultiplier = new Vector2(1, 1);
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        ///playerInput.currentActionMap.actions;
        //inputAssetplayerInput.GetComponent<InputActionAsset>();
        
        
        //2.5 and add .05 each time to meet fixedupdate(50 executes per sec)




        rb = GetComponent<Rigidbody2D>();
        //direction = new Vector2(0, 0);
    }


    //private void OnPress(InputAction actionPress) //takes a input value and checks when pressed, how long it held, and when its released, and changes certain values based on that
    //{
    //    //direction = value.Get<Vector2>();
    //
    //    if (actionPress == InputSystem.) { } //up
    //    else if (actionPress == ) { } //down
    //    else if (actionPress == ) { } //left
    //    else { } //right
    //}

    private void OnMove(InputValue value) //takes a input value and checks when pressed, how long it held, and when its released, and changes certain values based on that
    { //takes in Vector2
        direction.x = value.Get<Vector2>().x;
        direction.y = value.Get<Vector2>().y;

        
    }

    /*
    private void OnUp(InputAction action)
    {
        
        Debug.Log("accessed");
        Debug.Log(input + " input");

        //if (action.enabled)
        //{
        //    Debug.Log("enabled");
        //}
        //else
        //{
        //    Debug.Log("prolly disabed");
        //}

        //CallbackContext ctx = action.;

        //bool heldDown;
        //if (ctx.started)
        //{
        //    Debug.Log("held");
        //    heldDown = true;
        //}
        //    
        //if (ctx.performed)
        //{
        //    Debug.Log("released");
        //    heldDown = false;
        //}
            
        //direction.y = 1;
        //bool heldDown = true;
        //while (heldDown)
        //{
        //    chargeValueUp++;
        //    if(chargeValueUp >= 3)
        //    {
        //        chargeValueUp = 3f;
        //    }
        //}

        chargeValueUp = 10;


    }
    private void OnDown()
    {
        //direction.y = -1;
        chargeValueDown = 10;


    }
    private void OnLeft()
    {
        //direction.x = -1;
        chargeValueLeft = 10;


    }
    private void OnRight()
    {
        //direction.x = 1;
        chargeValueRight = 10;


    }*/

    private void OnJump(InputValue value)
    {
        if (direction.magnitude > 0f)
        {
            //for charge up(temp value of ten for all, change to 
            chargeValueUp -= chargeValueDown;   //takes positive axis value charges (right, up) and subtracts negative axis value charges (down, left)
            chargeValueRight -= chargeValueLeft;

            //direction.x *= chargeValueRight; //this version you have to keep input to go in that direction
            //direction.y *= chargeValueLeft;

            //direction.x = 1 * chargeValueRight; //directly sets direction before applying
            //direction.y = 1 * chargeValueLeft;

            //charge = new Vector2(chargeValueRight, chargeValueLeft); //makes new vector out of charge and applies
            ////if(direction.magnitude > 0)
            ////{
            ////    rb.velocity += direction * 10;
            ////}
            //rb.velocity += direction; //applies direction and charge to direction
            //rb.velocity += charge; //applies direction and charge to direction

            chargeValueUp = 0f; //resets charge value
            chargeValueDown = 0f;
            chargeValueLeft = 0f;
            chargeValueRight = 0f;
        }

        //Vector2.ClampMagnitude(rb.velocity, 1);
    }
    
    /*
    public void UpChange(Slider slider)
    {
        chargeValueUp = slider.value;
    }
    public void DownChange(Slider slider)
    {
        chargeValueDown = slider.value;
    }
    public void RightChange(Slider slider)
    {
        chargeValueRight = slider.value;
    }
    public void LeftChange(Slider slider)
    {
        chargeValueLeft = slider.value;
    }

    void UpdateMultiplyingValue()
    {
        chargeMultiplier.x = (chargeValueLeft + chargeValueRight);

        chargeMultiplier.y = (chargeValueUp + chargeValueDown);
    }
    */

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (direction.y >= 0.1f) //facing up
        {
            if(chargeValueUp < chargeMax)
            {
                chargeValueUp += chargeAddValue;
            }
            else
            {
                chargeValueUp = chargeMax;
            }
            Debug.Log("accessedUp");
        }

        if (direction.y <= -0.1f) //facing down
        {
            if (chargeValueDown < chargeMax)
            {
                chargeValueDown += chargeAddValue;
            }
            else
            {
                chargeValueDown = chargeMax;
            }
            Debug.Log("accessedDown");
        }

        if (direction.x <= -0.1f) //facing left
        {
            if (chargeValueLeft < chargeMax)
            {
                chargeValueLeft += chargeAddValue;
            }
            else
            {
                chargeValueLeft = chargeMax;
            }
            Debug.Log("accessedLeft");
        }

        if (direction.x >= 0.1f) //facing right
        {
            if (chargeValueRight < chargeMax)
            {
                chargeValueRight += chargeAddValue;
            }
            else
            {
                chargeValueRight = chargeMax;
            }
            Debug.Log("accessedRight");
        }




        if (rb.velocity.x >= maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if(rb.velocity.x <= -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.y >= maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeed);
        }
        if (rb.velocity.y <= -maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxSpeed);
        }





        if (direction.magnitude > 0)
        {
            rb.velocity += direction;
        }

        //if(rb.velocity.x > 0)
        //{
        //    rb.velocity -= new Vector2(deacceleration.x, 0);
        //}
        //if(rb.velocity.x < 0)
        //{
        //    rb.velocity += new Vector2(deacceleration.x, 0);
        //}
        //
        //if (rb.velocity.y > 0)
        //{
        //    rb.velocity -= new Vector2(0, deacceleration.y);
        //}
        //if (rb.velocity.y < 0)
        //{
        //    rb.velocity += new Vector2(0, deacceleration.y);
        //}

    }

}
