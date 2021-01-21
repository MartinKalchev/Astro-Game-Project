
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerHUD playerHUD;

    public Rigidbody2D rb;

    public GameObject player;


    void Start()
    {
        playerHUD = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHUD>();
    }


    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

        }

        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHUD.TakeDamage(20);

            StartCoroutine(Knockback(0.02f, 300, player.transform.position));
        }
    }


}