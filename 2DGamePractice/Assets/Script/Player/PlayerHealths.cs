using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealths : MonoBehaviour
{
    public Slider healthBar;
    public float MaxHealth = 100f;
    private float currentHealth;
    

    void Start()
    {
        currentHealth=MaxHealth;
        UpdateHealthBar();
        
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth<0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();

        
    }
}
