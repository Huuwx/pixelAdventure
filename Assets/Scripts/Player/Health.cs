using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        PlayerController.Instance.TakeDamageAnimation();
        currentHealth -= damage;
        
        if(currentHealth <= 0)
        {
            PlayerController.Instance.Defeated();
        }
    }
}
