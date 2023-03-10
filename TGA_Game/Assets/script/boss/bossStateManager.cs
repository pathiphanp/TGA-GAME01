using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStateManager : MonoBehaviour
{
    [Header("Boss Behavior")]
    public bool BossIdle;
    public bool IsChasing;
    public bool CloseAttack;
    public bool FarAttack;

    //ให้บอส ตบซักทีก่อน ถึงจะอรุญาตให้มัน โจมตีไกลกับผู้เล่นได้
    public bool AlreadyAttackClosePlayer;

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
        if(IsChasing == true || CloseAttack == true || FarAttack == true)
        {
            BossIdle = false;
        }
        else { BossIdle = true; }
        // Chasing
        if (distance <= 10 && CloseAttack == false && FarAttack == false)
        {
            IsChasing = true;
        }
        else { }
        // closeAttack
        if (distance <= 2)
        {
            IsChasing = false;
            CloseAttack = true;
        }
        else{CloseAttack = false;}
        // FarAttack
        if (distance > 10 && distance <= 20 && AlreadyAttackClosePlayer == true) //ถ้าบอสตามไม่ทัน มันจะหยุดวิ่งและตีไกล แต่ถ้าผู้เล่นอยู่ไกลเกินมันจะ idle
        {
            IsChasing = false;
            CloseAttack = false;
            FarAttack = true;
        }
        else { FarAttack = false; }
    }
}
