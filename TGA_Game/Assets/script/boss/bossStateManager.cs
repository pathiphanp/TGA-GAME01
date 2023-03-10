using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStateManager : MonoBehaviour
{
    public bool IsChasing;
    public bool CloseAttack;
    public bool FarAttack;
    public bool Idle;

    //เช็ครัศมี ระยะห่างกับผู้เล่น เพื่อใช้ในเงื่อนไขต่างๆ 
    public GameObject circleCenter; // reference to the game object representing the center of the circle
    public GameObject objectToMeasure; // reference to the game object representing the object to measure distance from
    public float distance;

    private void Update()
    {
        CheckDistance();
        AllowBehavior();
    }
    void CheckDistance()
    {
        distance = Vector3.Distance(circleCenter.transform.position, objectToMeasure.transform.position);
    }

    void AllowBehavior()
    {
        // Chasing
        if(distance <= 8)
        {
            IsChasing = true;
        }
        // closeAttack
        if (distance <= 2)
        {
            IsChasing = false;
            CloseAttack = true;
        }
        // FarAttack
        if (distance <= 6 && distance > 2)
        {
            IsChasing = false;
            CloseAttack = false;
            FarAttack = true;
        }
        else
        {
            FarAttack = false;
        }
    }
}
