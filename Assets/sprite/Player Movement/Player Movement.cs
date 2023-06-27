using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovementAnimation : MonoBehaviour
{
    //Speed (how fast the player will navigate on our game)
    public float moveSpeed;
    // Rigid body (handles physics)
    public Rigidbody2D rigidbody;
    //where the player is moving
    private Vector2 movementInput;
    //Acces to our Animator to Play animations
    public Animator anim;
    public int coinscount;
    // Start is called before the first frame update
    void Start()
    {
      rigidbody = GetComponent<Rigidbody2D>();
      anim  = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))

        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Forward");
        //}



        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Backward");
        //}




        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Left");
        //}




        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Right");
        //}


        //if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||Input.GetKeyUp(KeyCode.D))
        //{
        //    anim.enabled = false;
        //}
        anim.SetFloat("Horizontal",movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);




    }
    private void FixedUpdate()
    {
        rigidbody.velocity = movementInput * moveSpeed;
    }

    private void LateUpdate()
    {
        
    }
    //To get input system clicks
    private void OnMove(InputValue inputValue)
    {
    movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coins"))
        { 
        Destroy(collision.gameObject);
        coinscount++;
        }
        
    }

}
