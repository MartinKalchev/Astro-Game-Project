using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVision : MonoBehaviour
{
    public TurretAI turretAI;

    public bool isLeft = false;

    public Animator anim;


    void Awake()
    {
        turretAI = gameObject.GetComponentInParent<TurretAI>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

          anim.SetBool("IsCrouching", false);
            

            if (isLeft)
            {
                turretAI.Attack(false);
            }
            else
            {
                turretAI.Attack(true);
            }
        }

    }
}
