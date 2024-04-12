using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private bool grounded;
    private bool Fall = false;
    public Text Point;

    public float JumpForce = 0.5f;
    int countJump = 0;

    public Rigidbody2D Rigidbody;
    float horizontal;

    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    int Pointn = 0;
    // Start is called before the first frame update
    void Start()
    {
        Pointn = 0;
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        AMoving();
        Jump();
        animator.SetBool("grounded", grounded);
        Point.text = Pointn.ToString();
        if(countJump == 0 && grounded == false)
        {
            Fall = true;
            animator.SetBool("Fall", Fall);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }
    public void Jump()
    {
        if ((Input.GetButtonDown("Jump") && grounded) || Input.GetButtonDown("Jump") && countJump < 2)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpForce);
            if(countJump == 1)
            {
                animator.SetTrigger("DJump");
            }
            else
            {
                animator.SetTrigger("Jump");
            }
            countJump += 1;
            grounded = false;
            Debug.Log(countJump);
        }
        else if (grounded)
        {
            countJump = 0;
        }
    }
    public void Movement()
    {
        Vector2 pos = transform.position;
        pos.x = pos.x + 3.0f * horizontal * Time.deltaTime;
        transform.position = pos;
    }
    public void AMoving()
    {
        //Flip Player when moving left-right
        if (horizontal > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontal < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        animator.SetBool("IsMoving", horizontal != 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            Fall = false;
            animator.SetBool("Fall", Fall);
        }
        if(collision.gameObject.tag == "MelonFruit")
        {
            Pointn++;
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
