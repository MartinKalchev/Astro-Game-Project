using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingOctopus : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask obstacleLayers;
    public LayerMask turretLayers;


    public Transform obstacleCheck;
    public Transform turretCheck;


    bool isFacingRight = true;

    RaycastHit2D hit;
    RaycastHit2D hitTurret;


    private void Update()
    {
        hit = Physics2D.Raycast(obstacleCheck.position, -transform.up, 1f, obstacleLayers); // shoots a ray and checks if is colliding with ground
        hitTurret = Physics2D.Raycast(turretCheck.position, transform.right, 1f, turretLayers); // shoots a ray and checks if is colliding with turret

    }

    private void FixedUpdate()
    {
        if (hit.collider != false) // As long a collision with the Obstacle Layer is detected (detect ground)
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y); // right
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y); // left
            }
        }
        else // When there is no collision flip the sprite and the direction the enemy moves  (no ground detected)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }

        if (hitTurret.collider != true) // As long a collision with the Turret Layer is not detected (not detected turret)
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y); // right
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y); // left
            }
        }
        else // When there is a collision with a turret flip the sprite and the direction the enemy moves  (no turret detected)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }

    }


}
