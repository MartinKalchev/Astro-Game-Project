using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public Transform position1, position2;    // the range in which the platform will move
    public float speed;
    public Transform startPosition;
    Vector3 nextPosition;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = startPosition.position;
    }

    // Update is called once per frame
    void Update()
    {   // if the platform has moved left then move right
        if (transform.position == position1.position) {
            nextPosition = position2.position;
        }

        // if the platform has moved right then move left
        if (transform.position == position2.position) {
            nextPosition = position1.position;
        }

        // update the position of the platform
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.fixedDeltaTime);
    }
}