using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public Health health;
    public Healthbar healthBar;
    int HealthPoint = 10;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Potion")) {
            Heal(HealthPoint);
            Destroy(collision.gameObject);
        }
    }

    public void Heal(int hp)
    {
        if(health.currentHealth < 100)
        {
            health.currentHealth += hp;
            healthBar.SetHealth(health.currentHealth);
        }
    }
}
