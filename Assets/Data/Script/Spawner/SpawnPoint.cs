using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoint : HaoMonoBehaviour
{
    [SerializeField] protected Transform spawnPoint1;
    public Transform SpawnPoint1 => spawnPoint1;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoint();
    }

    protected virtual void LoadPoint()
    {
        if (spawnPoint1 != null) return;
        this.spawnPoint1 = transform;
        Debug.Log(transform.name + ": LoadPoint", transform.gameObject);
    }
}
