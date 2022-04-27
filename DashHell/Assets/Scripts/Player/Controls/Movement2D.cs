using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

/// <summary>
/// handles player movement
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    //movement values
    Rigidbody2D rb;
    Vector2 rbVel = Vector2.zero;
    Vector2 direction;
    float maxSpeed = 50f;
    public float multiplier = 1f;
    float count = 0f; //tracks how much speed multiplier has been gained

    //input
    [SerializeField]GameObject joystick;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_STANDALONE_WIN
        joystick.SetActive(false);
#endif
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnMove(InputValue value) //takes a input value and checks when pressed, how long it held, and when its released, and changes certain values based on that
    { //takes in Vector2
        direction.x = value.Get<Vector2>().x;
        direction.y = value.Get<Vector2>().y;
    }


    private void FixedUpdate()
    {
        rbVel = rb.velocity;//cache velocity
        
        if(rbVel.magnitude > maxSpeed) //check and control speed
        {
            rbVel = rbVel.normalized * maxSpeed;
        }
        rb.velocity = rbVel;

        if (direction.magnitude > 0) //if movin
        {
            rb.velocity += direction * multiplier;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger")) //if the score collider was hit
        {
            multiplier += 0.5f;
            count += 0.5f;
        }
        else
        {
            multiplier -= count;
            count = 0;
        }
    }

}
