using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarScript healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        Die();


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            TakeDamage(15);
        }else if (collision.gameObject.CompareTag("Spikes"))
            {
                gameObject.GetComponent<Animation>().Play("Player_Hurt");
            }


    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        gameObject.GetComponent<Animation>().Play("PlayerRedFlag");

        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }
}
