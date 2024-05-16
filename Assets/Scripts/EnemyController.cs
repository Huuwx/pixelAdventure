using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{

    public float Movdirection = -1f;
    public float MoveSpeed = 1.5f;

    public GameObject PointCheck;
    public Vector2 sizePointCheck;

    Rigidbody2D rigid;
    private Animator animator;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckGround();
        Movement();
        //FlipEnemies();
    }

    public void Movement()
    {
        rigid.velocity = new Vector2(Movdirection*MoveSpeed, rigid.velocity.y);
    }

    public void FlipEnemies()
    {
        if (Movdirection < 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (Movdirection > -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        animator.SetBool("IsMoving", Movdirection != 0);
    }

    private void CheckGround()
    {
        //RaycastHit2D[] colliders = Physics2D.RaycastAll(PointCheck.transform.position, Vector2.right * Movdirection, 3);
        //Debug.DrawRay(PointCheck.transform.position, Vector2.right * 3 * Movdirection);
        //foreach(RaycastHit2D ray in colliders)
        //{
        //    if (ray.collider.tag == "Ground")
        //    {
        //        if (Movdirection > 0)
        //        {
        //            Movdirection = -1;
        //            Debug.Log(Movdirection);
        //            return;
        //        }
        //        else
        //        {
        //            Movdirection = 1;
        //            return;
        //        }
        //    }
        //}

        Collider2D[] colliders = Physics2D.OverlapBoxAll(PointCheck.transform.position, sizePointCheck, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Ground")
            {
                if (Movdirection > 0)
                {
                    Movdirection = -1;
                    transform.localScale = Vector3.one;
                    return;
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    Movdirection = 1;
                    return;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(PointCheck.transform.position, new Vector3(sizePointCheck.x, sizePointCheck.y, 1f));
    }
}
