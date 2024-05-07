using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{

    public AudioClip eatFruit;

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
            PlayerController.countJump = 0;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            
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
        
    }

}
