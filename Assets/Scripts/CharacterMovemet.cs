using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovemet : MonoBehaviour
{

    [SerializeField]
    public float moveSpeed = 6f;
    [SerializeField]
    public float acceleration=3f;
    [SerializeField]
    public float decceleration=6f;
    [SerializeField]
    public float velocityPower=1f;
    [SerializeField]

    public float jumpStartTime;
    private float jumpTime;
    private bool isJumping;



    public Rigidbody2D rb;


    private float moveInput;
    private float jumpInput;
    private bool isFacingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float movement = run();
        rb.AddForce(movement * Vector2.right);

        
        
    }

    public float run()
    {

        #region Run
        // direction of the movement and desired velocity
        float targetSpeed = moveInput * moveSpeed;
        // calc diff bettwen current vel and desiredvel

        float speedDif = targetSpeed - rb.velocity.x;
        //change accl rate depending on situation
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velocityPower) * Mathf.Sign(speedDif);

        return movement;
        #endregion
    }

    public void jump()
    {

    }

    public void movementInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;

        if (moveInput > 0)
        {
            //animator.SetBool("isRunning", true);
            isFacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            //animator.SetBool("isRunning", true);
            isFacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);


        }
        else
        {
            //animator.SetBool("isRunning", false);

        }
        //Debug.Log("moving");
    }
    public void jumpingInput(InputAction.CallbackContext context)
    {
        //me procrastinating instead of making new jump
    }
}
