using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private static PlayerController instance;

    public static PlayerController Instance { get => instance; }

    public ParticleSystem Dust;
    public GameObject panelDoneGame;
    public Animator animator;
    public Rigidbody2D rb;
    private bool grounded;
    private bool canControl = false;

    public bool Wall = false;
    bool bamtuong;
    public static bool NinjaFrog;
    public static bool VirtualGuy;
    public static bool MaskDude;
    public Text Point;
    public Text LastPoint;
    public Text LastTxt;

    float horizontal;

    public GameObject PointinGame;
    public GameObject PointGroundCheck;
    public Vector2 sizeGroundCheck;
    public static int Pointn = 0;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    public void setCanControl()
    {
        canControl = true;
    }
    public void setGrounded(bool Grounded)
    {
        grounded = Grounded;
    }
    public bool getGrounded()
    {
        return grounded;
    }
    private bool Fall = false;
    public void setFall(bool fall)
    {
        Fall = fall;
    }
    public bool getFall()
    {
        return Fall;
    }

    //public float JumpForce = 0.5f;
    //public static int countJump = 0;
    //public Rigidbody2D Rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Pointn = 0;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetTrigger("Appearing");
        rb.gravityScale = 0f;
        //CheckCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if(!canControl) return;

        horizontal = PlayerMovement.Instance.GetMovInput();
        PlayerMovement.Instance.AMoving();
        PlayerMovement.Instance.Jump();
        grounded = CheckGround();
        animator.SetBool("grounded", grounded);
        Point.text = Pointn.ToString();
        PlayerMovement.Instance.CheckFall();
        checkMov();
    }

    private void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            PlayerMovement.Instance.Movement(horizontal);
        }
        else
        {
            if (KnockFromRight == true)
            {
                PlayerMovement.Instance.Rigidbody.velocity = new Vector2(-KBForce, KBForce);
            }
            else
            {
                PlayerMovement.Instance.Rigidbody.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }

    public float health;
    public float Health
    {
        set
        {
            animator.SetTrigger("TakeDamage");
            Debug.Log(value);
            health = value;
            if (health <= 0)
            {
                Defeated();
                //if(grounded == true)
                //{
                //    Time.timeScale = 0;
                //}
            }
        }
        get { return health; }
    }

    public void Defeated()
    {
        animator.SetTrigger("Dead");
    }

    public void SetGravityAfterStart()
    {
        rb.gravityScale = 1.2f;
    }

    public void Pause()
    {
        LastTxt.text = "Game Over";
        LastTxt.fontSize = 102;
        Time.timeScale = 0;
        LastPoint.text = Pointn.ToString();
        PointinGame.SetActive(false);
        panelDoneGame.SetActive(true);
    }

    public void Win()
    {
        LastTxt.text = "Congratulations !";
        LastTxt.fontSize = 70;
        Time.timeScale = 0;
        LastPoint.text = Pointn.ToString();
        PointinGame.SetActive(false);
        panelDoneGame.SetActive(true);
        gameObject.SetActive(false);
    }

    public void TakeDamage()
    {
        animator.SetTrigger("TakeDamage");
    }

    public void checkMov()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            setOutWallJump();
        }
    }

    private bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(PointGroundCheck.transform.position, sizeGroundCheck, 0);
        foreach (Collider2D collider in colliders)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" && grounded == false)
        {
            Debug.Log("tuong");
            rb.drag = 10f;
            Wall = true;
            animator.SetTrigger("WallJump");
            Fall = false;
            animator.SetBool("Fall", Fall);
            PlayerMovement.Instance.countJump = 0;

        }
        if (collision.gameObject.tag == "Ground")
        {

        }
        if (collision.gameObject.tag == "Trap")
        {
            KBCounter = KBTotalTime;
            if (collision.transform.position.x > transform.position.x)
            {
                KnockFromRight = true;
            }
            else
            {
                KnockFromRight = false;
            }
            Health -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door")
        {
            horizontal = 0;
            canControl = false;
            animator.SetTrigger("Desappearing");
        }
    }

    public void NextMap()
    {
        //HomeController.Instance.BackHomeScene();
    }
    public void setOutWallJump()
    {
        rb.drag = 0f;
        Wall = false;
    }

    void CreateDust()
    {
        Dust.Play();
    }

    //public void CheckFall()
    //{
    //    if (Rigidbody.velocity.y < 0)
    //    {
    //        Fall = true;
    //        animator.SetBool("Fall", Fall);
    //    }
    //}

    //public void Jump()
    //{
    //    if ((Input.GetButtonDown("Jump") && grounded) || Input.GetButtonDown("Jump") && countJump < 2)
    //    {
    //        JumpA();
    //        if(countJump == 1)
    //        {
    //            animator.SetTrigger("DJump");
    //        }
    //        else
    //        {
    //            animator.SetTrigger("Jump");
    //        }
    //        countJump += 1;
    //        Debug.Log(countJump);
    //    }
    //}

    //public void JumpA()
    //{
    //    Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpForce);
    //}

    //public void Movement()
    //{
    //    Vector2 pos = transform.position;
    //    pos.x = pos.x + 3.0f * horizontal * Time.deltaTime;
    //    transform.position = pos;
    //}
    //public void AMoving()
    //{
    //    //Flip Player when moving left-right
    //    if (horizontal > 0.01f)
    //    {
    //        transform.localScale = Vector3.one;
    //    }
    //    else if (horizontal < -0.01f)
    //    {
    //        transform.localScale = new Vector3(-1, 1, 1);
    //    }

    //    animator.SetBool("IsMoving", horizontal != 0);
    //}



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


}
