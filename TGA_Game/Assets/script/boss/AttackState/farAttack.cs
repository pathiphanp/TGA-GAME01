using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farAttack : MonoBehaviour
{
    bossStateManager bossmeg;
    public float DelayFarAttack = 7;

    private void Awake()
    {
        bossmeg = FindObjectOfType<bossStateManager>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        _FarAttack();
    }

    void _FarAttack()
    {
        if(bossmeg.FarAttack == true)
        {
            DelayFarAttack -= 0.01f;
            if(DelayFarAttack <= 0 && bossmeg.CountHardAttack < 3)
            {
                print("boss medium far attack!!!");
                bossmeg.CountHardAttack += 1;
                DelayFarAttack = 7;
            }
            else if (DelayFarAttack <= 0 && bossmeg.CountHardAttack >= 3)
            {
                print("boss [hard] far attack player!");
                bossmeg.CountHardAttack = 0;
                bossmeg.AlreadyAttackClosePlayer = true;
                DelayFarAttack = 7;
            }
        }
        else { }
    }
}
