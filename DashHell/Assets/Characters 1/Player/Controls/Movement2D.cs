using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;

    //InputAction actionHolder;

    float chargeAddValue = 0.05f;

    float chargeMax = 3f;

    float chargeValueUp = 1f;
    float chargeValueDown = 1f;
    float chargeValueLeft = 1f;
    float chargeValueRight = 1f;

    Vector2 chargeMultiplier = new Vector2(1, 1);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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

        #region testAddStuff



        #endregion
    }

    private void OnJump(InputValue value)
    {
        //Vector2.ClampMagnitude(direction, 1);
        

        //if (direction.magnitude > 0f && lastDirection.y == Vector2.down.y)
        //{
        //    //rb.velocity = direction * 0.25f;
        //    rb.velocity += direction * 10f;
        //}
        if (direction.magnitude > 0f)
        {
            //rb.velocity = direction * 0.25f;
            rb.velocity += (direction * chargeMultiplier);
        }

        //Vector2.ClampMagnitude(rb.velocity, 1);
    }

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

    // Update is called once per frame
    private void FixedUpdate()
    {

        Debug.Log(direction.x + " , "+ direction.y);

        if(chargeMultiplier.x <= 1f)
        {
            chargeMultiplier.x = 1;
        }

        if (chargeMultiplier.y <= 1f)
        {
            chargeMultiplier.y = 1;
        }

        UpdateMultiplyingValue();

        if(direction.y> 0.5f)                   //up
        { 
            if(chargeValueUp <= chargeMax)
            {
                chargeValueUp += chargeAddValue;
            }
            if(chargeValueUp >= 3)
            {
                chargeValueUp = 3;
            }
        }

        if (direction.y < -0.5f)                   //down
        {
            if (chargeValueDown <= chargeMax)
            {              
                chargeValueDown += chargeAddValue;
            }              
            if (chargeValueDown >= 3)
            {              
                chargeValueDown = 3;
            }
        }

        if (direction.x > 0.5f)                   //right
        {
            if (chargeValueRight <= chargeMax)
            {
                chargeValueRight += chargeAddValue;
            }
            if (chargeValueRight >= 3)
            {
                chargeValueRight = 3;
            }
        }

        if (direction.x < -0.5f)                   //left
        {
            if (chargeValueLeft <= chargeMax)
            {
                chargeValueLeft += chargeAddValue;
            }
            if (chargeValueLeft >= 3)
            {
                chargeValueLeft = 3;
            }
        }

        Debug.Log(chargeValueUp);
    }


    IEnumerator ChargeValue(float chargeValue)
    {



        yield return null;
    }

}
