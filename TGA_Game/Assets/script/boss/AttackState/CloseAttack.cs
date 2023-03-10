using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttack : MonoBehaviour
{
    public int CountCloseAttack; //��� boss ���ջ��Ԥú 3 �ѹ������˹ѡ 1 ���� ���ǡ�Ѻ����ջ�������
    bossStateManager bossmeg;
    float DelayAttack = 1;

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
            if(DelayAttack <= 0 && CountCloseAttack < 3)
            {
                print("boss [medium] closeattack player!");
                CountCloseAttack += 1;
                bossmeg.AlreadyAttackClosePlayer = true;
                DelayAttack = 7;
            }
            else if(DelayAttack <= 0 && CountCloseAttack >= 3)
            {
                print("boss [hard] closeattack player!");
                CountCloseAttack = 0;
                bossmeg.AlreadyAttackClosePlayer = true;
                DelayAttack = 7;
            }
        }
    }
}
