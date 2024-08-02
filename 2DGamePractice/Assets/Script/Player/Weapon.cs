using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PlayerController
{
    public float fAttackDuration=0.2f;
    public Collider2D cWeaponCollider;

    // Start is called before the first frame update
    void Start()
    {
       cWeaponCollider = GetComponent<Collider2D>();
       base.Start();
       cWeaponCollider.enabled = false; 
       if(cWeaponCollider!=null)
       {
        cWeaponCollider.isTrigger = true;
       }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Attack());           
        }
    }

    public  IEnumerator Attack() //角色攻擊動畫碰撞框消失
    {
        PlayerAttackAnim();
        yield return new WaitForSeconds(0.1f);
        cWeaponCollider.enabled = true;
        yield return new WaitForSeconds(fAttackDuration);
        cWeaponCollider.enabled = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }


    
}
