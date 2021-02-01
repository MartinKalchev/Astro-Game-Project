using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
        
        Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)   // if a hit is registered do damage to the enemy
		{
			enemy.TakeDamage(damage);  
		}

		Instantiate(impactEffect, transform.position, transform.rotation);  // instantiates the impact effect when a bullet hits the enemy

		Destroy(gameObject);
	}
	
}
