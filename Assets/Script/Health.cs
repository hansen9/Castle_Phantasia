using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    int damageSpike = 20;
    public Animator anim;
    public Healthbar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        anim.SetTrigger("hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Debug.Log("Enemy Died!");

        anim.SetBool("isDead", true);

        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;
        if(gameObject.CompareTag("Player") || gameObject.CompareTag("Boss")){
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Trap")){
            TakeDamage(damageSpike);
        }
    }

    void GameOver()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}