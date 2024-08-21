using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealths : MonoBehaviour
{
    public int iMaxHealth = 100;
    private int iCurrentHealth;
    public Slider sHealthBar;
    

    void Start()
    {
        iCurrentHealth=iMaxHealth;
        sHealthBar.maxValue = iMaxHealth;
        sHealthBar.value =iCurrentHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<PlayerHealths>().TakeDamage(10);
        }
        
    }

    

    protected void TakeDamage(int amount)
    {
        iCurrentHealth-=amount;
        if(iCurrentHealth<0)
        {
            iCurrentHealth=0;
        }
        sHealthBar.value = iCurrentHealth;
    }

    
}
