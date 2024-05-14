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

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckGround();
        Movement();
    }

    public void Movement()
    {
        rigid.velocity = new Vector2(Movdirection*MoveSpeed, rigid.velocity.y);
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
