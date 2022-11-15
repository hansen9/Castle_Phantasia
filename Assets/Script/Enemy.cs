using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");

        anim.SetBool("isDead", true);

        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;
    }
}
