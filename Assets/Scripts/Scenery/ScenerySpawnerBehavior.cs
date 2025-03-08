using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawnerBehavior : SpawnerBehavior
{   
    public override void Start()
    {
        base.Start();
    }

    public override void Awake()
    {
        // base.Awake();
    }

    public override IEnumerator RandomSpawn(float waitTime) {
        if (_entityPool != null) {
            while (GameManager.Instance.IsPlaying()) {
                yield return new WaitForSeconds(waitTime);
                int randomIndex = Random.Range(0, _entityPool.Count); 
                _entityPool[randomIndex].SetActive(true);
                waitTime = GenerateRandomInterval(_minInterval, _maxInterval);

            }   
        }
        
        
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
