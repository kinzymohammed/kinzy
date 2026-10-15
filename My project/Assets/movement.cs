using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movement : MonoBehaviour
{
    
    public float movespeed;
    public float jumph;
    public KeyCode L;
    public KeyCode R;
    public KeyCode space;

    public Transform groundcheck;
    public float r;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;

    void Start()
    {
anim=GetComponent<Animator>();
    }
    void Update (){

        if (Input.GetKey(L))
        {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, GetComponent<Rigidbody2D>().velocity.y);
        
        if(GetComponent<SpriteRenderer>().flipX != null)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        }
        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (Input.GetKey(R))
        {
        GetComponent <Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
        
     if(GetComponent<SpriteRenderer>()!= null)
     {
        GetComponent<SpriteRenderer>().flipX = false;

     }
        }


        if(Input.GetKeyDown(space)&& grounded)
        {
            jump();
        }
   
anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
anim.SetBool("Grounded", grounded);
    }
    
void jump()
    {
        
        
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumph);
        
    }




void FixedUpdate()
{
    grounded = Physics2D.OverlapCircle(groundcheck.position, r, whatIsGround);
}
}

