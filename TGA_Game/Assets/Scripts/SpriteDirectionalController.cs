using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirectionalController : MonoBehaviour
{
    [Range(0f, 180f)][SerializeField] float backAngle;
    [Range(0f, 180f)] [SerializeField] float sideAngle;
    [SerializeField] Transform mainTransfrom;
    [SerializeField] Animator animatior;
    [SerializeField] SpriteRenderer spriteRenderer;
    void LateUpdate()
    {
        Vector3 camForwardVecter = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        float signedAgle = Vector3.SignedAngle(mainTransfrom.forward, camForwardVecter, Vector3.up);
        Vector2 animationDrirection = new Vector2(0f, -1f);
        float angle = Mathf.Abs(signedAgle);

        if (angle < backAngle)
        {
            animationDrirection = new Vector2(0, -1f);
        }
        else if (angle < sideAngle)
        {
            if (signedAgle < 0)
            {
                //spriteRenderer.flipX = true;
                animationDrirection = new Vector2(-1f, 0);

            }
            else
            {
                animationDrirection = new Vector2(1f, 0);
                //spriteRenderer.flipX = false;
            }
            animationDrirection = new Vector2(1f, 0);

        }
        else
        {
            animationDrirection = new Vector2(0, 1f);
        }
        animatior.SetFloat("moveX", animationDrirection.x);
        animatior.SetFloat("moveY", animationDrirection.y);
    }
}
