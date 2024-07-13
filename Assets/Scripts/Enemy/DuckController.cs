using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : EnemyController
{
    public float JumpForceY;
    public float JumpForceX;
    private bool Fall;
    private bool turnBack = true;
    public GameObject PointGroundCheck;
    public Vector2 sizePointGroundCheck;

    public ParticleSystem JumpDust;

    public AudioClip jumpSound;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected void FixedUpdate()
    {
        CheckFall();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D (collision);
        if(collision.gameObject.tag == "Ground")
        {
            JumpSound();
            animator.SetTrigger("JumpAnticipation");
            CreateJumpDust();
            if (turnBack == true)
            {
                CheckWall();
            }
        }
    }

    public void CheckWall()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(PointCheck.transform.position, sizePointCheck, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Wall")
            {
                turnBack = false;
                Debug.Log("cham tuong");
                transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
                JumpForceX *= -1;
                return;
            }
        }
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
        CreateJumpDust();
        rigid.velocity = new Vector2(JumpForceX, JumpForceY);
    }

    public void CheckFall()
    {
        if (rigid.velocity.y < 0)
        {
            turnBack = true;
            Fall = true;
            animator.SetBool("Fall", Fall);
        }
        else
        {
            Fall = false;
            animator.SetBool("Fall", Fall);
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireCube(PointGroundCheck.transform.position, new Vector3(sizePointGroundCheck.x, sizePointGroundCheck.y, 1f));
    }

    public void CreateJumpDust()
    {
        JumpDust.Play();
    }

    public void JumpSound()
    {
        PlaySound(jumpSound);
    }
}
