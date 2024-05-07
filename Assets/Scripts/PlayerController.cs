using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private bool grounded;
    private bool Fall = false;
    public static bool NinjaFrog;
    public static bool VirtualGuy;
    public static bool MaskDude;
    public Text Point;

    public float JumpForce = 0.5f;
    public static int countJump = 0;

    public Rigidbody2D Rigidbody;
    float horizontal;

    public GameObject PointGroundCheck;
    public Vector2 sizeGroundCheck;
    public float groundCheckRadius = 0.2f;
    public static int Pointn = 0;
    // Start is called before the first frame update
    void Start()
    {
        Pointn = 0;
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //CheckCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        AMoving();
        Jump();
        grounded = CheckGround();
        animator.SetBool("grounded", grounded);
        Point.text = Pointn.ToString();
        CheckFall();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void CheckFall()
    {
        if (Rigidbody.velocity.y < 0)
        {
            Fall = true;
            animator.SetBool("Fall", Fall);
        }
    }

    public void Jump()
    {
        if ((Input.GetButtonDown("Jump") && grounded) || Input.GetButtonDown("Jump") && countJump < 2)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpForce);
            if(countJump == 1)
            {
                animator.SetTrigger("DJump");
            }
            else
            {
                animator.SetTrigger("Jump");
            }
            countJump += 1;
            Debug.Log(countJump);
        }
    }
    public void Movement()
    {
        Vector2 pos = transform.position;
        pos.x = pos.x + 3.0f * horizontal * Time.deltaTime;
        transform.position = pos;
    }
    public void AMoving()
    {
        //Flip Player when moving left-right
        if (horizontal > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontal < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        animator.SetBool("IsMoving", horizontal != 0);
    }

    private bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(PointGroundCheck.transform.position, sizeGroundCheck, 0);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Ground")
            {
                Fall = false;
                animator.SetBool("Fall", Fall);
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(PointGroundCheck.transform.position, new Vector3(sizeGroundCheck.x, sizeGroundCheck.y, 1f));
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        countJump = 0;
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "MelonFruit")
    //    {
    //        collision.gameObject.SetActive(false);
    //        Pointn++;
    //    }
    //}

    //public void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        grounded = false;
    //    }
    //}

    void CheckCharacter()
    {
        if (NinjaFrog == true)
        {
            CharacterSelection.Instance.SetActiveCharacter(true, false, false);
        }
        else if (VirtualGuy == true)
        {
            CharacterSelection.Instance.SetActiveCharacter(false, true, false);
        }
        else
        {
            CharacterSelection.Instance.SetActiveCharacter(false, false, true);
        }
    }
}
