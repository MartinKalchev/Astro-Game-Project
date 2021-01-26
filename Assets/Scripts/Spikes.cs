
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



}