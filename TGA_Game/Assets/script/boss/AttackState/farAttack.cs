using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farAttack : MonoBehaviour
{
    public int CountFarAttack; //��� boss ���ջ��Ԥú 3 �ѹ������˹ѡ 1 ���� ���ǡ�Ѻ����ջ�������
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
            if(DelayFarAttack <= 0 && CountFarAttack < 3)
            {
                print("boss medium far attack!!!");
                CountFarAttack += 1;
                DelayFarAttack = 7;
            }
            else if (DelayFarAttack <= 0 && CountFarAttack >= 3)
            {
                print("boss [hard] far attack player!");
                CountFarAttack = 0;
                bossmeg.AlreadyAttackClosePlayer = true;
                DelayFarAttack = 7;
            }
        }
        else { }
    }
}
