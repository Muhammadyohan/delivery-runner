using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public float score = 0;

    private bool isJump = false;
    private bool isSlide = false;
    private bool isSpeedBoost = false;

    private enum Lane {Lane1, Lane2, Lane3};
    private Lane lane;
    private Vector3 lanePos;
    private Transform thisTransform;
    private Animator anim;
    private Rigidbody rbody;
    private CapsuleCollider playerCollider;

    [SerializeField] private float speedBoostForSpeedBooster = 1f;
    [SerializeField] private float switchLaneDistance = 1;
    [SerializeField] private float switchLaneSpeed = 1;
    [SerializeField] private float moveForwardSpeed = 0.1f;
    [SerializeField] private float jumpForce = 5f;


    void Awake()
    {
        thisTransform = transform;
        lanePos.x = thisTransform.position.x;
    }

    void Start()
    {
        lane = Lane.Lane2;
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {   
        //Endless Move Forward
        transform.Translate(0, 0, moveForwardSpeed);

        //Speed Boost Handle
        SpeedBoostHandler();

        //Key Bind Input
        InputHandler();

        //Moving Left or Right Handle
        lanePos = new Vector3(lanePos.x, thisTransform.position.y, thisTransform.position.z);
        transform.position = Vector3.MoveTowards(thisTransform.position, lanePos, Time.deltaTime * switchLaneSpeed);

        AnimatorHandle();
    }

    private void InputHandler()
    {
        //Prees W for Jump
        if (Input.GetKeyDown(KeyCode.W))
            isJump = true;
        else if (Input.GetKeyUp(KeyCode.W))
            isJump = false;
        //Prees S for Slide
        if (Input.GetKeyDown(KeyCode.S))
            isSlide = true;
        else if (Input.GetKeyUp(KeyCode.S))
            isSlide = false;
        //Prees A for moving left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (lane != Lane.Lane1)
            {
                lanePos = new Vector3(lanePos.x - switchLaneDistance, thisTransform.position.y, thisTransform.position.z);
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
                lanePos = new Vector3(lanePos.x + switchLaneDistance, thisTransform.position.y, thisTransform.position.z);
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

    private void AnimatorHandle()
    {
        anim.SetBool("isJump", isJump);
        anim.SetBool("isSlide", isSlide);
    }

    private void SpeedBoostHandler()
    {
        if (isSpeedBoost)
        {
            transform.Translate(0, 0, speedBoostForSpeedBooster);
            playerCollider.enabled = false;
            rbody.isKinematic = true;
        }
        else
        {
            playerCollider.enabled = true;
            rbody.isKinematic = false;
        }
    }

    IEnumerator SpeedBoostController()
    {
        isSpeedBoost = true;
        yield return new WaitForSeconds(3);
        isSpeedBoost = false;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Speed Booster")
        {
            Destroy(other.gameObject);
            StartCoroutine(SpeedBoostController());
        }

        if (other.gameObject.tag == "Pizza")
        {
            Destroy(other.gameObject);
            score += 1;
        }
    }
}
