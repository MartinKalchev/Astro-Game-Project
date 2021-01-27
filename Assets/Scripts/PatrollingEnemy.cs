using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public LayerMask turretLayers;
    public LayerMask spikesLayers;

    public Transform groundCheck;
    public Transform turretCheck;
    public Transform spikesCheck;

    bool isFacingRight = true;

    RaycastHit2D hit;
    RaycastHit2D hitTurret;
    RaycastHit2D hitSpikes;

    private void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers); // shoots a ray and checks if is colliding with ground
        hitTurret = Physics2D.Raycast(turretCheck.position, transform.right, 1f, turretLayers); // shoots a ray and checks if is colliding with turret
        hitSpikes = Physics2D.Raycast(spikesCheck.position, transform.right, 1f, spikesLayers); // shoots a ray and checks if is colliding with spikes
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

        if (hitSpikes.collider != true) // As long a collision with the Spikes Layer is not detected (not detected spikes)
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
        else // When there is a collision with a spikes flip the sprite and the direction the enemy moves  (no spikes detected)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }


    }


}
