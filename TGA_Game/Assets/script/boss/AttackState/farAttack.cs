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
            DelayFarAttack -= 0.5f;
            if(DelayFarAttack <= 0)
            {
                print("boss far attack!!!");
                DelayFarAttack = 7;
            }
        }
        else { }
    }
}
