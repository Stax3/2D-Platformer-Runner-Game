using System;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 2f;      // The force applied when the player jumps
    public float forwardSpeed = 5f;   // The player's constant forward movement speed
    public LayerMask groundLayer;     // The layer containing the ground

    public Rigidbody2D rb;           // Reference to the player's rigidbody
    private bool isGrounded;          // Is the player grounded?
    private bool canJump;             // Can the player jump right now?
    private int mouseclicks = 0;

    private EnemyManager _enemyManager;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _enemyManager = FindObjectOfType<EnemyManager>();
    }

    void Update()
    {
        // Check if the player is grounded
        //isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer);
        animator.SetBool("isRunning", true);
        canJump = false;
        isGrounded = true;
        // Allow the player to jump if grounded and the screen is tapped
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isjumping");
            canJump = true;
            Debug.Log("Player is on ground! ");
                
            Jump();
                
        }
    }
    

   /* void FixedUpdate()
    {
        // Move the player forward at a constant speed
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);
    }
    */

    void Jump()
    {
            
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            mouseclicks ++;
            Debug.Log(mouseclicks);
            isGrounded = false;
            //rb.velocity = new Vector2(forwardSpeed, 0);
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I hit an enemy!");
            //enemy.explode();
            // Handle the collision with an object tagged as "Enemy"
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.StartInteraction();
        }
    }
    
    

    public void ResetJump()
    {
        canJump = false;
    }



}