using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement instance;

    public static PlayerMovement Instance { get => instance; }

    public float moveSpeed = 3f;
    public float JumpForce = 7f;
    public static int countJump = 0;

    private Animator animator;
    public Rigidbody2D Rigidbody;
    float horizontal;
    private bool Fall = false;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerMovement.instance != null) { Debug.LogError("Only 1 SoundController allow to exist!"); }
        PlayerMovement.instance = this;
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void SetTriggerJump()
    {
        animator.SetTrigger("Jump");
    }

    public float GetMovInput()
    {
        return horizontal = Input.GetAxis("Horizontal");
    }

    public void Movement(float horizontal)
    {
        Vector2 pos = transform.position;
        pos.x = pos.x + moveSpeed * horizontal * Time.deltaTime;
        transform.position = pos;

    }

    public void CheckFall()
    {
        if (Rigidbody.velocity.y < 0)
        {
            Fall = true;
            animator.SetBool("Fall", Fall);
        }
        else
        {
            Fall = false;
            animator.SetBool("Fall", Fall);
        }
    }

    public void setFloatA(float countJump)
    {
        animator.SetFloat("countJump", countJump);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && countJump < 2)
        {
            JumpA();
            if (countJump == 1)
            {
                animator.SetTrigger("DJump");
            }
            else
            {
                animator.SetTrigger("Jump");
            }
            countJump += 1;
            setFloatA(countJump);
            Debug.Log(countJump);
        }
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



    public void JumpA()
    {
        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpForce);
    }
}
