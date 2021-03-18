using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour

{
    public CharacterController2D controller;

    public Animator animator;
    public float runspeed = 40f;
    float horizontalmove = 0f;
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalmove));

        if(Input.GetButtonDown("jump"))
        {
            jump = true;
        }
        if(Input.GetButtonDown("crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

     void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
    }
}
