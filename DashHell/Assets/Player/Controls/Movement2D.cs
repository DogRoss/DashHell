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
    [SerializeField]GameObject joystick;

    float maxSpeed = 50f;

    bool isBraking = false;

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
#if UNITY_STANDALONE_WIN
        joystick.SetActive(false);
#endif
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value) //takes a input value and checks when pressed, how long it held, and when its released, and changes certain values based on that
    { //takes in Vector2
        direction.x = value.Get<Vector2>().x;
        direction.y = value.Get<Vector2>().y;

        
    }

    private void OnPause()
    {
        Debug.Log("Paused");
        Application.Quit();
    }


    private void FixedUpdate()
    {

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

    }

}
