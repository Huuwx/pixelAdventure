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

    private static EnemyController instance;

    public static EnemyController Instance { get => instance; }

    public float Movdirection = 0f;
    public float MoveSpeed = 1.5f;
    private bool isMoving = false;

    public Transform target;
    public GameObject PointCheck;
    public Vector2 sizePointCheck;
    public GameObject CheckposPlayer;
    public Vector2 sizeCheckPosPlayer;
    public GameObject CheckdamPlayer;
    public Vector2 sizeCheckdamPlayer;

    Rigidbody2D rigid;
    private Animator animator;

    public float health;
    public float Health
    {
        set
        {
            //animator.SetTrigger("IsTakeDamage");
            Debug.Log(value);
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
        get { return health; }
    }

    void Start()
    {
        if (EnemyController.instance != null) { Debug.LogError("Only 1 SoundController allow to exist!"); }
        EnemyController.instance = this;
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Defeated()
    {
        animator.SetTrigger("Dead");
    }

    public void RemoveEnemy()
    {
        gameObject.SetActive(false);
        Debug.Log("ga chet");
    }

    private void FixedUpdate()
    {
        CheckPlayer();
        damagePlayer();
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

    private void damagePlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(CheckdamPlayer.transform.position, sizeCheckdamPlayer, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Player")
            {
                Debug.Log("hihi");
                PlayerController.Instance.Health -= 1;
            }
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
                else if (target.position.x > transform.position.x)
                {
                    Movdirection = 1f;
                    distance = new Vector3(2f, 0, 0);
                }
                isMoving = true;
                animator.SetBool("IsMoving", isMoving);
                if (Mathf.Abs(transform.position.x - target.position.x) <= 1.8f)
                {
                    Movdirection = 0f;
                    isMoving = false;
                    animator.SetBool("IsMoving", isMoving);
                }
            }
        }
        if (colliders.Length == 1)
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
        Gizmos.DrawWireCube(CheckdamPlayer.transform.position, new Vector3(sizeCheckdamPlayer.x, sizeCheckdamPlayer.y, 1f));
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        PlayerController.Instance.Health -= 1;
    //        //PlayerController.Instance.TakeDamage();
    //    }
    //}

}
