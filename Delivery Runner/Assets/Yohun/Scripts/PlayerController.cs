using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private bool isJump = false;
    private bool isSlide = false;

    private Animator anim;
    private Rigidbody rbody;
    private CapsuleCollider playerCollider;

    private bool isSpeedBoost = false;
    [SerializeField] private float speedBoostForSpeedBooster = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {   
        //Endless Move Forward
        transform.Translate(0, 0, 0.1f);

        //Speed Boost Handle
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

        //Prees W for Jump
        if (Input.GetKeyDown(KeyCode.W))
            isJump = true;
        else
            isJump = false;
        //Prees S for Slide
        if (Input.GetKeyDown(KeyCode.S))
            isSlide = true;
        else
            isSlide = false;

        //-------------Animation Handle-------------
        if (isJump)
        {
            anim.SetBool("isJump", isJump);
            transform.Translate(0, 0.3f, 0.1f);
        }
        else if (!isJump)
        {
            anim.SetBool("isJump", isJump);
        }

        if (isSlide)
        {
            anim.SetBool("isSlide", isSlide);
            transform.Translate(0, 0, 0.1f);
        }
        else if (!isSlide)
        {
            anim.SetBool("isSlide", isSlide);
        }
        //--------------------------------------------
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Speed Booster")
        {
            Destroy (other.gameObject);
            StartCoroutine(SpeedBoostController());
        }
    }

    IEnumerator SpeedBoostController()
    {
        isSpeedBoost = true;
        yield return new WaitForSeconds(3);
        isSpeedBoost = false;
    }

}
