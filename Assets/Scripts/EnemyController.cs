using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{

    public float Movdirection = 0f;
    public float MoveSpeed = 1.5f;
    private bool isMoving = false;

    public Transform target;
    public GameObject PointCheck;
    public Vector2 sizePointCheck;
    public GameObject CheckposPlayer;
    public Vector2 sizeCheckPosPlayer;

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
        CheckDistance();
        CheckPlayer();
        Movement();
        FlipEnemies();
    }

    public void Movement()
    {
        rigid.velocity = new Vector2(Movdirection * MoveSpeed, rigid.velocity.y);
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
                    Movdirection = -1f;
                    return;
                }
                else
                {
                    Movdirection = 1f;
                    return;
                }
            }
            else if (collider.tag == "Player")
            {
                if (target.position.x < transform.position.x)
                {
                    Movdirection = -1f;
                }
                else
                {
                    Movdirection = 1f;
                }
                isMoving = true;
                animator.SetBool("IsMoving", isMoving);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
                rigid.MovePosition(temp);
            }
            else
            {
                Movdirection = 0f;
                isMoving = false;
                animator.SetBool("IsMoving", isMoving);
            }
        }
    }

    public void CheckDistance()
    {
        if(Mathf.Abs(transform.position.x - target.position.x) <= 2f)
        {
            Movdirection = 0f;
            isMoving = false;
            animator.SetBool("IsMoving", isMoving);
        }
    }

    public void CheckPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(CheckposPlayer.transform.position, sizeCheckPosPlayer, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Player")
            {
                Vector3 distance;
                if (target.position.x < transform.position.x)
                {
                    Movdirection = -1f;
                    distance = new Vector3(-2f, 0, 0);
                }
                else if(target.position.x > transform.position.x)
                {
                    Movdirection = 1f;
                    distance = new Vector3(2f, 0, 0);
                }
                isMoving = true;
                animator.SetBool("IsMoving", isMoving);
                if (Mathf.Abs(transform.position.x - target.position.x) <= 2f)
                {
                    Movdirection = 0f;
                    isMoving = false;
                    animator.SetBool("IsMoving", isMoving);
                }
            }
        }
        if(colliders.Length == 1)
        {
            Movdirection = 0f;
            isMoving = false;
            animator.SetBool("IsMoving", isMoving);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(PointCheck.transform.position, new Vector3(sizePointCheck.x, sizePointCheck.y, 1f));
        Gizmos.DrawWireCube(CheckposPlayer.transform.position, new Vector3(sizeCheckPosPlayer.x, sizeCheckPosPlayer.y, 1f));
    }
}
