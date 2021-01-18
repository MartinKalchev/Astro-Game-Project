using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    bool isRewinding = false;

    Rigidbody2D rb;
    public Animator animator;

    public GameObject grayOutEffect;
    List<PointInTime> pointsInTime;
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] m_AnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        //Output the name of the starting clip
        // Debug.Log("Starting clip : " + m_AnimatorClipInfo[0].clip);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            stopRewind();    
        }
    }

    void FixedUpdate()
    {
        if (isRewinding) {
            Rewind();
        } else {
            Record();
        }
    }

    void Rewind()
    {
        grayOutEffect.SetActive(true);
        if (pointsInTime.Count > 0) {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        } else {
            stopRewind();
        }
    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(5f / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void stopRewind()
    {
        grayOutEffect.SetActive(false);
        isRewinding = false;
    }
}