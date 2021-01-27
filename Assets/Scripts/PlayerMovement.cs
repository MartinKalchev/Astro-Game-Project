using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public int pickupCount = 0;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool isRewinding = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isRewinding = true;
            return;
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            isRewinding = false;
        }

        if (isRewinding)
        {
            return;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }



    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
