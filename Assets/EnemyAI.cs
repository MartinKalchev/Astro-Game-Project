using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behaviour")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;


    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);

    }

    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }


    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        //Reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        // See if colliding with anything
        isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);

        //Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        // Jump
        if (jumpEnabled && isGrounded)
        {
            if(direction.y > jumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }
        }

        //Movement
        rb.AddForce(force);

        //Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Direction Graphics Handling
        if(directionLookEnabled)
        {
            if(rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }



    //public Transform target;

    //public float speed = 200f;
    //public float nextWaypointDistance = 3f;

    //public Transform enemyGFX;

    //Path path;
    //int currentWaypoint = 0;
    //bool reachedEndOfPath = false;

    //Seeker seeker;
    //Rigidbody2D rb;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    seeker = GetComponent<Seeker>();
    //    rb = GetComponent<Rigidbody2D>();

    //    InvokeRepeating("UpdatePath", 0f, .5f);
    //}

    //void UpdatePath()
    //{
    //    if (seeker.IsDone())
    //        seeker.StartPath(rb.position, target.position, OnPathComplete);
    //}

    //void OnPathComplete(Path p)
    //{
    //    if (!p.error)
    //    {
    //        path = p;
    //        currentWaypoint = 0;
    //    }
    //}


    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    if (path == null)
    //        return;

    //    if (currentWaypoint >= path.vectorPath.Count)
    //    {
    //        reachedEndOfPath = true;
    //        return;
    //    }else
    //    {
    //        reachedEndOfPath = false;
    //    }

    //    Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
    //    Vector2 force = direction * speed * Time.deltaTime;

    //    rb.AddForce(force);

    //    float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

    //    if (distance < nextWaypointDistance)
    //    {
    //        currentWaypoint++;
    //    }

    //    if (force.x >= 0.01f)
    //    {
    //        enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
    //    }
    //    else if (force.x <= -0.01f)
    //    {
    //        enemyGFX.localScale = new Vector3(1f, 1f, 1f);
    //    }

    //}
}
