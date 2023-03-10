using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttack : MonoBehaviour
{
    bossStateManager bossmeg;

    //attack----------------
    [SerializeField] Collider hitboxCloseAttack;

    float DelayAttack = 1;
    float DisapearHitbox = 5f;

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
            if(DelayAttack <= 0 && bossmeg.CountHardAttack < 3)
            {
                print("boss [medium] closeattack player!");
                StartCoroutine(Attack());
                bossmeg.CountHardAttack += 1;
                bossmeg.AlreadyAttackClosePlayer = true;
                DelayAttack = 7;
            }
            else if(DelayAttack <= 0 && bossmeg.CountHardAttack >= 3)
            {
                print("boss [hard] closeattack player!");
                StartCoroutine(Attack());
                bossmeg.CountHardAttack = 0;
                bossmeg.AlreadyAttackClosePlayer = true;
                DelayAttack = 7;
            }
        }
    }

    IEnumerator Attack()
    {
        hitboxCloseAttack.enabled = true; //collider attack is on
        yield return new WaitForSeconds(DisapearHitbox);
        hitboxCloseAttack.enabled = false; //collider attack is off
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by boss attack!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited boss attack collider!");
        }
    }
}
