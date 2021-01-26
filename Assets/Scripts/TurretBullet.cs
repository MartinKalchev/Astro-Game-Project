using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Pickup")
        //{
        //    Physics.IgnoreCollision(collision.GetComponent<Collider>(), GetComponent<Collider>());
        //}

        if (collision.isTrigger != true)
        {
            Destroy(gameObject);
        }
    }
}
