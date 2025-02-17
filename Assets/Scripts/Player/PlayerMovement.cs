using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement instance;
    public static PlayerMovement Instance { get => instance; }

    private bool IsMoving = false;
    public bool getIsMoving()
    {
        return IsMoving;
    }
    public float moveSpeed = 3f;
    public float JumpForce = 7f;
    public float JumpTrampolineForce = 10f;
    public float WallJumpForce = 0.5f;
    public int countJump = 0;

    private Animator animator;
    public Rigidbody2D Rigidbody;
    float horizontal;
    private bool Fall = false;


    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) { Debug.LogError("Only 1 SoundController allow to exist!"); }
        instance = this;
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
        //Rigidbody.velocity = new Vector2(horizontal * moveSpeed, Rigidbody.velocity.y);
    }

    public void CheckFall()
    {
        if (PlayerController.Instance.Wall == false)
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
    }

    public void setFloatA(float countJump)
    {
        animator.SetFloat("countJump", countJump);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && countJump < 2)
        {
            PlayerController.Instance.JumpSound();
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
        if (horizontal != 0)
        {
            IsMoving = true;
            if (horizontal > 0.01f)
            {
                transform.localScale = Vector3.one;
                WallJumpForce = -0.5f;
            }
            else if (horizontal < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                WallJumpForce = 0.5f;
            }
        }
        else
        {
            IsMoving = false;
        }

        animator.SetBool("IsMoving", IsMoving);
    }



    public void JumpA()
    {
        if (PlayerController.Instance.Wall == false)
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpForce);
        else
        {
            Debug.Log("nhay tuong");
            Rigidbody.velocity = new Vector2(WallJumpForce, JumpForce);
            PlayerController.Instance.setOutWallJump();
        }
    }

    public void JumpTrampoline()
    {
        countJump = 2;
        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpTrampolineForce);
    }
}
