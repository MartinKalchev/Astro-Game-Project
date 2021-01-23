using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    public Rigidbody2D rb;

    public HealthBarScript healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);

        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, gameObject.transform.position.z));

        }

        yield return 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            TakeDamage(15);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            TakeDamage(10);

            StartCoroutine(Knockback(0.02f, 500, gameObject.transform.position));
        }
        else if (collision.CompareTag("TurretBullet"))
        {
            TakeDamage(10);
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
