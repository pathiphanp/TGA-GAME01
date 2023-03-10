using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] Collider attackCollider;
    bossStateManager bossmeg;
    private void Awake()
    {
        bossmeg = FindObjectOfType<bossStateManager>();
    }
    void Start()
    {

    }

    void Update()
    {
        AllowCooliderToHitPlayer();
    }


    void AllowCooliderToHitPlayer()
    {
    }
}
