using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerController.Instance.CreateFallDust();
            PlayerMovement.Instance.countJump = 0;
            PlayerMovement.Instance.setFloatA(0);
            PlayerController.Instance.setOutWallJump();
            PlayerController.Instance.setFall(false);
            PlayerController.Instance.animator.SetBool("Fall", PlayerController.Instance.getFall());
        }
        if (collision.gameObject.tag == "Dead")
        {
            PlayerController.Instance.Health -= 10000;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "stupidChicken")
        {
            stupidChickenController stupidChicken = collision.gameObject.GetComponent<stupidChickenController>();
            stupidChicken.Health -= 1;
            PlayerMovement.Instance.SetTriggerJump();
            PlayerMovement.Instance.JumpA();
        }
        else if (collision.gameObject.tag == "DuckDuck")
        {
            Debug.Log("cham vit");
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
        else if(collision.gameObject.tag == "Trampoline")
        {
            Debug.Log("nhay");
            TrampolineController.Instance.SetTriggerAnimation();
            PlayerMovement.Instance.SetTriggerJump();
            PlayerMovement.Instance.JumpTrampoline();
        }
    }

}
