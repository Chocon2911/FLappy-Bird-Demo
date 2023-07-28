using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawner : Spawner
{
    [SerializeField] protected LandSpawnerCtrl landSpawnerCtrl;

    protected string prefabName = "Road_1";

    protected virtual void Update()
    {
        this.SpawnLandTilHolderEmpty();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLandSpawnerCtrl();
    }

    protected virtual void LoadLandSpawnerCtrl()
    {
        if (landSpawnerCtrl != null) return;
        this.landSpawnerCtrl = transform.GetComponent<LandSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadLandSpawnerCtrl", transform.gameObject);
    }

    protected virtual void SpawnLandTilHolderEmpty()
    {
        Vector3 pos = landSpawnerCtrl.LandSpawnPoint.SpawnPoint1.position;
        Quaternion rot = landSpawnerCtrl.LandSpawnPoint.SpawnPoint1.rotation;
        if (this.holder.childCount < 6)
        {
            Transform prefab = this.Spawn(prefabName, pos, rot);
            this.RandomPrefab();

            prefab.gameObject.SetActive(true);
            Debug.Log(transform.name + ": SpawnLandTilHolderEmpty", transform.gameObject);
        }
        else
        {
            return;
        }
    }
}
