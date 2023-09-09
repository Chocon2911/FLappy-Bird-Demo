using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawnerCtrl : HaoMonoBehaviour
{
    [SerializeField] protected LandSpawnPoint landSpawnPoint;
    public LandSpawnPoint LandSpawnPoint => landSpawnPoint;

    [SerializeField] protected LandSpawner landSpawner;
    public LandSpawner LandSpawner => landSpawner;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLandSpawner();
        this.LoadLandSpawnPoint();
    }

    protected virtual void LoadLandSpawnPoint()
    {
        if (landSpawnPoint != null) return;
        landSpawnPoint = GameObject.Find("SpawnPointLand").GetComponent<LandSpawnPoint>();
        Debug.Log(transform.name + ": LoadLandSpawnPoint", transform.gameObject);
    }
    
    protected virtual void LoadLandSpawner()
    {
        if(landSpawner != null) return;
        landSpawner = transform.GetComponent<LandSpawner>();
        Debug.Log(transform.name + ": LoadLandSpawner", transform.gameObject);
    }
}
