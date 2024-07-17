using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Action OnPlayerDamaged;
    //public HealthHeartsBar heartsBar;

    public int maxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //heartsBar.DrawHearts();
    }

    public void TakeDamage(int damage)
    {
        PlayerController.Instance.TakeDamageAnimation();
        currentHealth -= damage;
        OnPlayerDamaged?.Invoke();
        
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            PlayerController.Instance.Defeated();
        }
    }
}
