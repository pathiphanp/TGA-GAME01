using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooklTarget : MonoBehaviour
{
    public Transform target;

    //private Quaternion originalRotation; //lock rotation แกน x ไม่ให้มัน เคลื่อนตามเพลเยอร์

    
    void Start()
    {
       // originalRotation = transform.rotation;
    }

    
    void Update()
    {
        transform.LookAt(target);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.green);
        //transform.rotation = Quaternion.Euler(originalRotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
