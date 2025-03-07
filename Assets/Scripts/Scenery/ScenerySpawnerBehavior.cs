using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawnerBehavior : SpawnerBehavior
{   
    public override void Start()
    {
        // _entityPool = InitializeObjectPool(_maxEntityCount, _prefabsToSpawn);
        // _initialIntervalTime = GenerateRandomInterval(_minInitialWaitTimeInterval, _maxInitialWaitTimeInterval);
        // StartCoroutine(RandomSpawn(_initialIntervalTime));

        base.Start();
        Debug.Log("scenery start");
    }
    

    public override List<GameObject> InitializeObjectPool(int maxEntityCount, List<GameObject> prefabsToSpawn) {
        List<GameObject> entityPool = new List<GameObject>();
        for (int i = 0; i < maxEntityCount; i++) {
            int j = Random.Range(0, prefabsToSpawn.Count);
            GameObject newObj = Instantiate(prefabsToSpawn[j], transform);
            newObj.name += newObj.GetInstanceID();
            newObj.SetActive(false);
            entityPool.Add(newObj);    
            Collider newObjCollider = newObj.GetComponent<Collider>();
            GameManager.Instance.SceneryManager.AddSceneryObject(newObj, newObjCollider.bounds);

        }
        

        return entityPool;

        
    }

    
}
