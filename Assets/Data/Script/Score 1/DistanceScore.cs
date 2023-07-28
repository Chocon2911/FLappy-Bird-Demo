using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScore : HuyMonoBehaviour
{
    public float distanceCount;

    protected virtual void FixedUpdate()
    {
        this.GetDistanceScore();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }
    protected virtual void GetDistanceScore()
    {
        this.distanceCount += 1;
    }
}
