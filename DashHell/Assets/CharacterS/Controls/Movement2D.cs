using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;

    

    Vector2 lastDirection;

    float chargeMax = 100f;

    float chargeValueUp = 0f;
    float chargeValueDown = 0f;
    float chargeValueLeft = 0f;
    float chargeValueRight = 0f;

    float topChargeValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnMove(InputValue value) //takes a input value and checks when pressed, how long it held, and when its released, and changes certain values based on that
    {
        direction = value.Get<Vector2>();        

        Debug.Log(direction.x + " , " + direction.y);



        
        //while(direction == lastDirection)
        //{
        //    if (chargeValue < 100f)
        //    {                   //check if max charge and adds to charge if held down
        //        chargeValue += .2f;
        //    }
        //    
        //}
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
            rb.velocity += direction * 7f;
        }

        //Vector2.ClampMagnitude(rb.velocity, 1);
    }

    private void IncrementUp(int switchCase)
    {

    }

    private float UpdateTopValue() 
    {

        return 2f;
    }

    // Update is called once per frame
    private void Update()
    {
        if(direction.magnitude >= 0.95f) //stores direction as long as there is a directional input
        {
            lastDirection = direction;
        }

        if(lastDirection == Vector2.down)
        {

        }

        UpdateTopValue();

        //if(chargeValue > 0)
        //{
        //    chargeValue -= .1f;
        //}
        
    }
}
