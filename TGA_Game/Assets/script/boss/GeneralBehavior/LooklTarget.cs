using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooklTarget : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction from the object to the player
        Vector3 direction = player.position - transform.position;

        // Calculate the rotation angle around the Y axis
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Create a quaternion rotation based on the angle
        Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

        // Apply the rotation to the object's transform
        transform.rotation = rotation;
    }
}

