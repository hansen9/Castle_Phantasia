using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 25;
    public int attackDamagePierce = 50;
    public float attackRate = 2f;
    private float nextAttackTime = 0;
    public int manaConsumption = 25;
    public Mana manaNow;
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown("z"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown("x"))
            {
                Pierce();
            }
        }
        
    }

    void Attack()
    {
        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("player hit " + enemy.name);
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }

    void Pierce()
    {
        if (manaNow.currentMana >= manaConsumption)
        {
            manaNow.TakeMana(manaConsumption);
            anim.SetTrigger("attackB");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("player hit " + enemy.name);
                enemy.GetComponent<Health>().TakeDamage(attackDamagePierce);
            }
        }else {
            Debug.Log("out of mana");
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
