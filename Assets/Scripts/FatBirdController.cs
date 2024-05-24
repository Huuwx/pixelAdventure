using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBirdController : EnemyController
{

    public Vector3 HomePos;
    bool isNotHome;

    protected override void Start()
    {
        base.Start();
        HomePos = transform.position;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (isNotHome)
        {
            BackHomePos();
        }
    }

    public override void CheckPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(CheckposPlayer.transform.position, sizeCheckPosPlayer, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Player")
            {
                rigid.velocity = new Vector2(rigid.velocity.x, -1 * MoveSpeed);
                isMoving = true;
                animator.SetBool("IsMoving", isMoving);
            }
        }
        if (colliders.Length == 1)
        {
            
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D (collision);
        if(collision.collider.tag == "Ground")
        {
            isMoving = false;
            animator.SetBool("IsMoving", isMoving);
            Invoke(nameof(setIsNotHome), 1.5f);

        }
        Debug.Log("==");
    }

    private void setIsNotHome()
    {
        isNotHome = true;
    }

    private void BackHomePos()
    {
        Debug.Log("Quay ve");
        Vector3 temp = Vector3.MoveTowards(transform.position, HomePos, MoveSpeed * Time.deltaTime);
        rigid.MovePosition(temp);
        if(transform.position == HomePos)
        {
            isNotHome = false;
        }
    }
}
