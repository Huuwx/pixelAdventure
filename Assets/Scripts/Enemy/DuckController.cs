using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : EnemyController
{
    public int countJump = 0;
    public float JumpForceY;
    public float JumpForceX;
    private bool Fall;
    private bool turnBack = true;
    public GameObject PointGroundCheck;
    public Vector2 sizePointGroundCheck;




    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected void FixedUpdate()
    {
        CheckFall();
        JumpMovement();
        //if (Fall == false)
        //{
        //    CheckWall();
        //}
    }

    public void JumpMovement()
    {
        Collider2D[] colliers = Physics2D.OverlapBoxAll(PointGroundCheck.transform.position, sizePointGroundCheck, 0);
        foreach (Collider2D col in colliers)
        {
            if (col.gameObject.tag == "Ground" && Fall == false)
            {
                //if(countJump == 0)
                //{
                //    Jump();
                //    countJump += 1;
                //}
                //Invoke(nameof(resetCountJump), 5f);
                animator.SetTrigger("JumpAnticipation");
                if(turnBack == true)
                {
                    CheckWall();
                }
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

    public void resetCountJump()
    {
        countJump = 0;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireCube(PointGroundCheck.transform.position, new Vector3(sizePointGroundCheck.x, sizePointGroundCheck.y, 1f));
    }
}
