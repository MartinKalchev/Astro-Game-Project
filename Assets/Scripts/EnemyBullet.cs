using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{


    public float speed = 10f;
    public int damage = 15;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHUD player = hitInfo.GetComponent<PlayerHUD>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    //public float dieTime;
    //public GameObject dieEffect;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    StartCoroutine(CountDownTimer());
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Die();
    //}

    //IEnumerator CountDownTimer()
    //{
    //    yield return new WaitForSeconds(dieTime);

    //    Die();
    //}

    //void Die()
    //{
    //    Destroy(gameObject);
    //}
}
