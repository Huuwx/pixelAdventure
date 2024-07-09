using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBirdController : EnemyController
{
    public ParticleSystem FlyDustLeft;
    public ParticleSystem FlyDustRight;
    public ParticleSystem FallDust;

    public Vector3 HomePos;
    bool isNotHome;

    protected override void Start()
    {
        base.Start();
        HomePos = transform.position;
    }

    protected void FixedUpdate()
    {
        CheckPlayerFB();
        if (isNotHome)
        {
            BackHomePos();
        }
    }

    public void CheckPlayerFB()
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
        //if (colliders.Length == 1)
        //{
            
        //}
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(collision.gameObject.tag == "Ground")
        {
            CreateFallDust();
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

    public void CreateFlyDust()
    {
        FlyDustLeft.Play();
        FlyDustRight.Play();
    }

    public void CreateFallDust()
    {
        FallDust.Play();
    }
}
