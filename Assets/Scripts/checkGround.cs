using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{

    public AudioClip eatFruit;
    public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerMovement.Instance.countJump = 0;
            PlayerMovement.Instance.setFloatA(0);
            PlayerController.Instance.setOutWallJump();
            PlayerController.Instance.setFall(false);
            PlayerController.Instance.animator.SetBool("Fall", PlayerController.Instance.getFall());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MelonFruit")
        {
            PlayerController.Pointn += 1;
            collision.gameObject.SetActive(false);
            SoundController.Instance.PlaySound(eatFruit);
        }
        else if (collision.gameObject.tag == "stupidChicken")
        {
            stupidChickenController stupidChicken = collision.gameObject.GetComponent<stupidChickenController>();
            stupidChicken.Health -= 1;
            PlayerMovement.Instance.SetTriggerJump();
            PlayerMovement.Instance.JumpA();
        }
        else if (collision.gameObject.tag == "DuckDuck")
        {
            DuckController duck = collision.gameObject.GetComponent<DuckController>();
            duck.Health -= 1;
            PlayerMovement.Instance.SetTriggerJump();
            PlayerMovement.Instance.JumpA();
        }
        else if (collision.gameObject.tag == "FatBird")
        {
            FatBirdController fb = collision.gameObject.GetComponent<FatBirdController>();
            fb.Health -= 1;
            PlayerMovement.Instance.SetTriggerJump();
            PlayerMovement.Instance.JumpA();
        }
    }

}
