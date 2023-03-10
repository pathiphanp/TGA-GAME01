using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttack : MonoBehaviour
{
    bossStateManager bossmeg;
    public float DelayAttack = 7;

    private void Awake()
    {
        bossmeg = FindObjectOfType<bossStateManager>();
    }
    void Start()
    {
        
    }


    void Update()
    {
        _CloseAttack();
    }
    
    void _CloseAttack()
    {
        if(bossmeg.CloseAttack == true)
        {
            DelayAttack -= 0.01f;
            if(DelayAttack <= 0)
            {
                print("boss attack player!");
                DelayAttack = 7;
            }
        }
    }
}
