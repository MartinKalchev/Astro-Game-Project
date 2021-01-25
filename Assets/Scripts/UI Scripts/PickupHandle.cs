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
        if(collision.gameObject.name == "Player")
        {
            GameObject.Destroy(pickup);

            //image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;

            //if(pm.pickupCount == 4)
            if (pm.pickupCount == 3)
            {
                Debug.Log(pm.pickupCount);
                Debug.Log("You won!!!");
                //SceneManager.LoadScene("WinScreen");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            pm.pickupCount++;
        }
    }
}
