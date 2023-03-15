using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float maxDistance = 10f;
    public float stoppingDistance = 2f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Calculate the direction and distance to the player
        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;

        // If the player is within max distance, move towards them
        if (distance <= maxDistance)
        {
            // If there's nothing in front of us, move towards the player
            if (!Physics.Raycast(transform.position, transform.forward, stoppingDistance))
            {
                rb.velocity = direction.normalized * speed;
            }
            else // If there's something in front of us, stop moving
            {
                rb.velocity = Vector3.zero;
            }
        }
        else // If the player is outside max distance, stop moving
        {
            rb.velocity = Vector3.zero;
        }
    }

}
