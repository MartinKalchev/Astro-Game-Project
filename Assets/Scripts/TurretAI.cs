using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
   
    public float distanceToPlayer;
    public float wakeRange;      // Range in which animation activates
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public bool awake = false;       // initially turret is not risen from the ground
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft, shootPointRight;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

  
    void Update()
    {

        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);

        
            RangeCheck();
        


        if ( target != null && target.transform.position.x > transform.position.x)   // determines if player is right or left from the turret
        {
            lookingRight = true;
        }

        if (target != null && target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }
    }

    // Function that checks if the player is in the attack range of the turret
    void RangeCheck()
    {

        distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer < wakeRange)
        {
            awake = true;
        }

        if (distanceToPlayer > wakeRange)
        {
            awake = false;
        }
    }

    public void Attack(bool attackingRight)
    {

        bulletTimer += Time.deltaTime;

        if (target != null && bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;

            direction.Normalize();

            if(!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
   
                bulletTimer = 0;

            }

            if (attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }
        }

    }


}
