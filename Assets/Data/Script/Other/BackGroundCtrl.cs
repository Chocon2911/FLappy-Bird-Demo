using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BackGroundCtrl : HuyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.isKinematic = true;
    }
}
