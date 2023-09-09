using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveToLeft : HaoMonoBehaviour
{
    [SerializeField] protected BackGroundCtrl backgroundCtrl;
    public float speed = 100f;

    protected override void Start()
    {
        base.Start();
    }

    protected virtual void FixedUpdate()
    {
        this.ObjMoveToLeft();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBackgroundCtrl();
    }

    protected virtual void LoadBackgroundCtrl()
    {
        if (this.backgroundCtrl != null) return;
        this.backgroundCtrl = transform.GetComponent<BackGroundCtrl>();
        Debug.Log(transform.name + ": LoadBackgroundCtrl", transform.gameObject);
    }

    protected virtual void ObjMoveToLeft()
    {
        this.backgroundCtrl.Rb.velocity = Vector2.left * this.speed * Time.fixedDeltaTime;
    }
}
