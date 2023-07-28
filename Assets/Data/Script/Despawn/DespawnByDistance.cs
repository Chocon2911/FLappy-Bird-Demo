using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distanceX;
    [SerializeField] protected float limitDistance = -17.5f;

    protected override void Start()
    {
        base.Start();
    }
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.distanceX = transform.parent.position.x;
    }

    protected override bool CanDespawn()
    {
        if(distanceX >= limitDistance) return false;
        return true;
    }
}
