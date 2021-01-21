﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger != true)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHUD>().TakeDamage(5);
            }
            Destroy(gameObject);
        }
    }
}
