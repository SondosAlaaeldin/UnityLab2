using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movespeed;
    public float jumpheight;
    public KeyCode spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundcheckerRadius;
    public LayerMask WhatIsGround;
    private bool grounded;
   private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(spacebar) && grounded){
            Jump();
        }
        if(Input.GetKey(L)){
            GetComponent<Rigidbody2D>().velocity=new Vector2(-movespeed,GetComponent<Rigidbody2D>().velocity.y);
            if(GetComponent<SpriteRenderer>()!=null){GetComponent<SpriteRenderer>().flipX=true;}
        }
        if(Input.GetKey(R)){
            GetComponent<Rigidbody2D>().velocity=new Vector2(movespeed,GetComponent<Rigidbody2D>().velocity.y);
            if(GetComponent<SpriteRenderer>()!=null){GetComponent<SpriteRenderer>().flipX=false;}
        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
     anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
     anim.SetBool("Grounded", grounded);
    }
     
    void Jump(){
        GetComponent<Rigidbody2D>().velocity= new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpheight);
    }

 }

     void FixedUpdate(){
        grounded=Physics2D.OverlapCircle(groundCheck.position,groundcheckerRadius,WhatIsGround);
    }
}
