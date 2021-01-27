using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickupHandle : MonoBehaviour
{
    public GameObject pickup;
    public GameObject player;
    public Image image;
    public PlayerMovement pm;

    public void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
        // if colliding with player
        if(collision.gameObject.name == "Player")
        {
            GameObject.Destroy(pickup);

            //The collected part gets coloured by maxing out the alpha channel
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;

            //If all spaceship parts are collected the win screen is loaded
            if (pm.pickupCount == 4)
            {
                Debug.Log(pm.pickupCount);
                Debug.Log("You won!!!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            pm.pickupCount++;
        }
    }
}
