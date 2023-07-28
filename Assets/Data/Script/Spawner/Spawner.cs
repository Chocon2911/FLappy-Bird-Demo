using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : HuyMonoBehaviour
{
    [SerializeField] protected Transform holder;

    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
        this.LoadPrefab();
    }

    //used to assign Transform"Holder" -> Transform holder
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", transform.gameObject);
    }

    //Find every child in Prefabs and Add it to List prefabs
    protected virtual void LoadPrefab()
    {
        if (this.prefabs.Count > 0) return;
            Transform PrefabObj = transform.Find("Prefabs");
            foreach (Transform prefab in PrefabObj)
            {
                this.prefabs.Add(prefab);
            }

        Debug.Log(transform.name + ": LoadPrefab", transform.gameObject);
    }

    //SetActive(false) to every child in List prefabs(detail in LoadPrefab())
    protected virtual void HidePrefab()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    //if name of obj exist by checking from GetPrefabByName(string prefabName)
    //if yes take its name and get the position, rotation you added
    //(no need to be position and rotation from obj with that name)
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }

        return this.Spawn(prefab, spawnPos, rotation);
    }

    //with the name, pos, rot you had check above, set pos and rot to the obj with that name
    //then add it to be child of Transform holder
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.holder;
        this.spawnedCount++;
        return newPrefab;
    }

    //Check what obj you want to clone by assign it to GetObjectFromPool(...)
    //and using its name to check if any child in List poolObjs has the same name as its
    //if none then clone the new one
    //if exist then clone that child and remove that child from List poolObjs
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if(poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    //Despawn the obj and add to List PoolObjs by assign that obj to that empty Despawn(...)
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }

    //Find children in List prefabs by using their names
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    //take random one of child in List prefabs
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];  
    }
}
