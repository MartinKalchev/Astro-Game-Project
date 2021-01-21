using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public int curHealth;
    public int maxHealth;

    public float distanceToPlayer;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft, shootPointRight;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {

        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);

        if(target != null)
        {
            RangeCheck();
        }


        if ( target != null && target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }

        if (target != null && target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }
    }

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
