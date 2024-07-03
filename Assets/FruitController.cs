using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    private Animator animator;
    public AudioClip eatFruit;

    void Start()
    {
        animator= GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController.Pointn += 1;
            animator.SetTrigger("Collected");
            //SoundController.Instance.PlaySound(eatFruit);
        }
    }

    public void DestroyFruit()
    {
        Destroy(gameObject);
    }
}
