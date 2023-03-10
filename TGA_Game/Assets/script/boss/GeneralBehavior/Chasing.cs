using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    bossStateManager bossmeg;

    public Transform player;
    public float moveSpeed = 5f;

    private bool canSeePlayer = true; // flag to track if the boss can see the player

    private void Awake()
    {
        bossmeg = FindObjectOfType<bossStateManager>();
    }
    private void Start()
    {

    }
    private void Update()
    {
        ChasingPlayer();
    }

    IEnumerator WaitAndCheckForPlayer()
    {
        yield return new WaitForSeconds(1f); // wait for 1 second before checking again

        // calculate direction to player
        Vector3 dirToPlayer = player.position - transform.position;

        // check if there is an obstacle between the boss and the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dirToPlayer, out hit))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                // the player is visible again, so resume chasing
                canSeePlayer = true;
            }
        }
    } //เช็ค ยังว่าหาเจอมั้ยทุกๆ 1 วิ ถ้าผู้เล่นหายไปจากสายตา
    void ChasingPlayer() //เอาโค้ดเช็คระยะห่างมากำหนดการเคลื่อนไหวของบอส การไล่จะหยุดลงเมื่อผู้เล่นแอบหลังบางอย่าง
    {
        if (canSeePlayer && bossmeg.IsChasing == true)
        {
            //boss manager check 
            bossmeg.IsChasing = true;
            // calculate direction to player
            Vector3 dirToPlayer = player.position - transform.position;

            // move towards player
            transform.Translate(dirToPlayer.normalized * moveSpeed * Time.deltaTime, Space.World);

            // check if there is an obstacle between the boss and the player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dirToPlayer, out hit))
            {
                if (hit.collider.gameObject.tag != "Player")
                {
                    // the boss cannot see the player, so stop chasing
                    canSeePlayer = false;
                    print("can't see wUw");
                }
            }
        } //ผู้เล่นห่างจากบอส 8 ไล่เลย 
        else
        {
            // the boss cannot see the player, so wait and periodically check if player is visible again
            StartCoroutine(WaitAndCheckForPlayer());
            //boss manager check 
            bossmeg.IsChasing = false;
        }
    }

}
