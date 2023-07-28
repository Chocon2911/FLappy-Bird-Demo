using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : Spawner
{
    protected float delayTime = 0f;
    protected float rateTime = 1.5f;
    protected float posX = 15f;

    [SerializeField] protected float minHeight = 0f;
    [SerializeField] protected float maxHeight = 3f;

    protected string prefabName = "Pipe_1";

    protected override void Start()
    {
        base.Start();
        this.SpawnByTime();
    }

    protected virtual void SpawnObject()
    {
        float posY = Random.Range(minHeight, maxHeight);
        Vector3 pos = new Vector3(posX, posY, 0);
        Quaternion rot = transform.rotation;

        Transform prefab = this.Spawn(prefabName, pos, rot);
        prefab.gameObject.SetActive(true);
        Debug.Log(transform.name + ": SpawnObject", transform.gameObject);
    }

    protected virtual void SpawnByTime()
    {
        InvokeRepeating("SpawnObject", delayTime, rateTime);
        Debug.Log(transform.name + ": SpawnByTime", transform.gameObject);
    }
}
