using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BirdFly : MonoBehaviour
{
    public float range;
    float maxDistance = 5f;
    public Transform TargetJoint2D;

    void Start()
    {
        TargetJoint2D = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        trackPlayer();
    }

    private void trackPlayer()
    {
        range  = Vector2.Distance(transform.position, TargetJoint2D.position);
        if (range < maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetJoint2D.position, 4f * Time.deltaTime);
        }
        
        
    }
}
