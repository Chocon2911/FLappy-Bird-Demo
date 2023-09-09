using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : HaoMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    public PlayerCtrl PlayerCtrl => playerCtrl;

    public bool isJumping = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", transform.gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.Jump();
    }

    protected virtual void Jump()
    {
        if (InputManager.Instance.jumpHeight > 0)
        {
            isJumping = true;
            PlayerCtrl.Rb.velocity = Vector2.up * InputManager.Instance.jumpHeight;
            Debug.Log("nhay roi");
        }
        else
        {
            PlayerCtrl.Rb.velocity = Vector2.zero;
            isJumping = false;
        }
    }
}