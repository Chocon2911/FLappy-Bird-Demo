using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : HuyMonoBehaviour
{
    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;

    protected float rotZ;
    protected virtual void FixedUpdate()
    {
        this.Fall();
        this.PlayerRotateWhenJumped();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerMovement();
    }

    protected virtual void LoadPlayerMovement()
    {
        if (playerMovement != null) return;
        this.playerMovement = transform.GetComponent<PlayerMovement>();
    }

    protected virtual void Fall()
    {
        if (playerMovement.isJumping == true)
        {
            playerMovement.PlayerCtrl.Rb.gravityScale = 0f;
        }
        else
        {
            if (playerMovement.PlayerCtrl.Rb.gravityScale > 15) playerMovement.PlayerCtrl.Rb.gravityScale = 15f;
            playerMovement.PlayerCtrl.Rb.gravityScale += 15f * Time.fixedDeltaTime;
            Debug.Log("roi xuong");
        }
    }
    
    protected virtual void PlayerRotateWhenJumped()
    {
        if(playerMovement.isJumping == true)
        {
            rotZ = 35f;
        }
        if(playerMovement.isJumping == false && playerMovement.PlayerCtrl.Rb.velocity.y <= 0)
        {
            if(rotZ < -90)
            {
                rotZ = -90f;
            }
            else
            {
                rotZ -= 135 * Time.fixedDeltaTime;
            }
        }
        transform.parent.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
