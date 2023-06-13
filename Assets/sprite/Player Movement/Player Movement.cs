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
    // Start is called before the first frame update
    void Start()
    {
      rigidbody = GetComponent<Rigidbody2D>();
      anim  = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            anim.SetTrigger("Forward");
        }

        if (Input.GetKeyUp(KeyCode.S)) 
        {
            anim.SetTrigger("Forward animation pause");
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Backward");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetTrigger("Backward Animation pause");
        }


        if (Input.GetKeyDown(KeyCode.A)) 
        {
            anim.SetTrigger("Left");
        }


        if (Input.GetKeyUp(KeyCode.A)) 
        {
            anim.SetTrigger("Left Animation Pause");
        }

        if (Input.GetKeyDown(KeyCode.D)) 
        {
            anim.SetTrigger("Right");
        }

        if (Input.GetKeyUp(KeyCode.D)) 
        {
            anim.SetTrigger("Right Animation Pause");
        }

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
}
