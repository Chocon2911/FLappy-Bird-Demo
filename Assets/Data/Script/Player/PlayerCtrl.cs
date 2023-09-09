using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EdgeCollider2D))]
public class PlayerCtrl : HaoMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected EdgeCollider2D edgeCollider2D;
    public EdgeCollider2D EdgeCollider2D => edgeCollider2D;
    protected override void LoadComponent()
    {
        this.LoadRigidbody();
        this.LoadEdgeCollider2D();
    }
    
    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = 10f;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void LoadEdgeCollider2D()
    {
        if(edgeCollider2D != null) return;
        this.edgeCollider2D = transform.GetComponent<EdgeCollider2D>();
        Debug.Log(transform.name + ": LoadCircleCollider", gameObject);
    }
}
