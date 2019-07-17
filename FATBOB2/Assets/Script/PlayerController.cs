using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpVelocity;
    private Rigidbody2D playerRigidbody;
    public bool IsGrounded = true;
    public Animator animator;
    public GameManager GameManagerInstance;
    public BoxCollider2D collider;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetAxis("Jump") == 1 && transform.position.y <= -0.75f)
        {
            animator.SetBool("Jump", true);
            playerRigidbody.velocity = new Vector2(0.0f, JumpVelocity);
            IsGrounded = false;
        }

        IsGrounded = true;
        

      if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("Crouch", true);
           collider.size = new Vector2(collider.size.x, 200f);
        }

      if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("Crouch", false);
            collider.size = new Vector2(collider.size.x, 408f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "EvilPaperObstacle(Clone)")
        {
            Debug.Log("Ouch!");
            GameManagerInstance.OnPlayerHit();
        }

        if (other.gameObject.name == "AngryPhoneObstacle(Clone)")
        {
            Debug.Log("Ouch!");
            GameManagerInstance.OnPlayerHit();
        }

        if (other.gameObject.name == "roadeded")
        {
            animator.SetBool("Jump", false);
        }
    }
 }

    