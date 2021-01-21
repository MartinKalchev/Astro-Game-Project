using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    PlayerHUD playerHUD;

    private void Start()
    {
        playerHUD = GetComponent<PlayerHUD>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (/*collision.gameObject.CompareTag("Enemy") ||*/ playerHUD.currentHealth <= 0)
        {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }


}
