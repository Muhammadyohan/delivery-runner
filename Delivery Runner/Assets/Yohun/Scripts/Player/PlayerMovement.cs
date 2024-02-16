using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public UnityEvent GameOver;

    public float speed;
    [HideInInspector] public float speedBuffer;

    [SerializeField] private float jumpForce;
    [SerializeField] private float buttonGracePeriod;
    [SerializeField] private float fallingCheckNum = 5;
    [SerializeField] private float laneSwitchSpeed = 1;
    [SerializeField] private float laneSwitchDistance = 1;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    private bool isGrounded;
    private bool isRolling = false;
    private float magnitude;
    private Vector3 velocity;

    private bool rollingIframe;

    private enum Lane {Lane1, Lane2, Lane3};
    private Lane lane;
    private Vector3 lanePos;

    void Start()
    {
        speedBuffer = speed;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        lane = Lane.Lane2;
    }

    void Update()
    {
        //Endless Running Calculate
        Vector3 moveMentDirection = new Vector3(0, 0, 1);
        magnitude = Mathf.Clamp01(moveMentDirection.magnitude) * speed;
        moveMentDirection.Normalize();

        //Gravity
        ySpeed += Physics.gravity.y * Time.deltaTime;



        //Coyote Time and Jump Buffer
        if (characterController.isGrounded)
            lastGroundedTime = Time.time;

        //Jumping Keybind
        if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Jump"))
            jumpButtonPressedTime = Time.time;

        //Sliding Keybind
        if (Input.GetKeyDown(KeyCode.S))
        {
            ySpeed = -3;
            isRolling = true;
        }

        if (Time.time - lastGroundedTime <= buttonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            //Handle Animator
            animator.SetBool("IsGrounded", true);
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            isJumping = false;
            animator.SetBool("IsFalling", false);

            //Slide animation when prees slide key and on the ground
            if (isRolling)
            {
                StartCoroutine(SlidingAnimationHandler());
                isRolling = false;
            }

            if (Time.time - jumpButtonPressedTime <= buttonGracePeriod)
            {
                ySpeed = jumpForce;

                //Handle Animator
                animator.SetBool("IsJumping", true);
                isJumping = true;

                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;

            //Handle Animator
            animator.SetBool("IsGrounded", false);
            isGrounded = false;

            if ((isJumping && ySpeed < 0) || ySpeed < fallingCheckNum)
            {
                animator.SetBool("IsFalling", true);
            }
        }

        //Calculate for Making Character Move
        velocity = moveMentDirection * magnitude;
        velocity.y = ySpeed;

        //Lane switch 
        LaneSwitchInputHandler();
        lanePos = new Vector3(lanePos.x, transform.position.y, transform.position.z);

        //Lane switching
        MoveTowardsTarget(lanePos);

        //Movement
        characterController.Move(velocity * Time.deltaTime);
        }

    private void MoveTowardsTarget(Vector3 target)
    {
        var cc = GetComponent<CharacterController>();
        var offset = target - transform.position;
        if (offset.magnitude > .1f)
        {
            offset = offset.normalized * laneSwitchSpeed;
            cc.Move(offset * Time.deltaTime);
        }
    }

    private void LaneSwitchInputHandler()
    {
        //Prees A for moving left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (lane != Lane.Lane1)
            {
                lanePos = new Vector3(lanePos.x - laneSwitchDistance, transform.position.y, transform.position.z);
                if (lane == Lane.Lane3)
                {
                    lane = Lane.Lane2;
                }
                else if (lane == Lane.Lane2)
                {
                    lane = Lane.Lane1;
                }
            }
        }
        //Prees D for moving right
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (lane != Lane.Lane3)
            {
                lanePos = new Vector3(lanePos.x + laneSwitchDistance, transform.position.y, transform.position.z);
                if (lane == Lane.Lane1)
                {
                    lane = Lane.Lane2;
                }
                else if (lane == Lane.Lane2)
                {
                    lane = Lane.Lane3;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Obstacle")
        {
            animator.SetBool("IsKnockDown", true);
            GameOver.Invoke();
        }
    }

    IEnumerator SlidingAnimationHandler()
    {
        animator.SetBool("IsRolling", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("IsRolling", false);
    }
}