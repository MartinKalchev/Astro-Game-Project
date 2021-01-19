using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerHUD playerHUD;

    void Start()
    {
        playerHUD.GetComponent<PlayerHUD>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHUD.TakeDamage(20);
        }
    }


}
