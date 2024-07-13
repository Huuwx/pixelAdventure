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
    protected bool isMoving = false;

    public Transform target;
    public GameObject PointCheck;
    public Vector2 sizePointCheck;
    public GameObject CheckposPlayer;
    public Vector2 sizeCheckPosPlayer;
    

    protected Rigidbody2D rigid;
    protected Animator animator;

    private AudioSource audioSource;
    public AudioClip hitSoundE;

    public float health;
    public float Health
    {
        set
        {
            HitSoundE();
            Debug.Log("-1");
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
        get { return health; }
    }

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
    public void minusHP(float damage)
    {
        Health -= damage;
    }

    public virtual void Movement()
    {
        rigid.velocity = new Vector2(Movdirection * MoveSpeed, rigid.velocity.y);
    }

    public void FlipEnemies()
    {
        if (Movdirection < -0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (Movdirection > 0.01f)
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
        }
    }

    public virtual void CheckPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(CheckposPlayer.transform.position, sizeCheckPosPlayer, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Player")
            {
                if (target.position.x < transform.position.x)
                {
                    Movdirection = -1f;
                }
                else if (target.position.x > transform.position.x)
                {
                    Movdirection = 1f;
                }
                isMoving = true;
                animator.SetBool("IsMoving", isMoving);
                //if (Mathf.Abs(transform.position.x - target.position.x) <= 1.8f)
                //{
                //    Movdirection = 0f;
                //    isMoving = false;
                //    animator.SetBool("IsMoving", isMoving);
                //}
            }
        }
        if (colliders.Length == 2)
        {
            Movdirection = 0f;
            isMoving = false;
            animator.SetBool("IsMoving", isMoving);

        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(PointCheck.transform.position, new Vector3(sizePointCheck.x, sizePointCheck.y, 1f));
        Gizmos.DrawWireCube(CheckposPlayer.transform.position, new Vector3(sizeCheckPosPlayer.x, sizeCheckPosPlayer.y, 1f));
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.Instance.KBCounter = PlayerController.Instance.KBTotalTime;
            if (collision.transform.position.x < transform.position.x)
            {
                PlayerController.Instance.KnockFromRight = true;
            }
            else
            {
                PlayerController.Instance.KnockFromRight = false;
            }
            PlayerController.Instance.Health -= 1;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void HitSoundE()
    {
        PlaySound(hitSoundE);
    }
}
