using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool jump = false;
    public bool slide = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.1f);

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            slide = true;
        }
        else
        {
            slide = false;
        }

        if (jump)
        {
            anim.SetBool("isJump", jump);
            transform.Translate(0, 0.3f, 0.1f);
        }
        else if (!jump)
        {
            anim.SetBool("isJump", jump);
        }

        if (slide)
        {
            anim.SetBool("isSlide", slide);
            transform.Translate(0, 0, 0.1f);
        }
        else if (!slide)
        {
            anim.SetBool("isSlide", slide);
        }
    }
}
