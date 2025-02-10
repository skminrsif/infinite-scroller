using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    // public enum EntityType {
    //     Obstacle,
    //     Enemy
    // }

    // [SerializeField] private EntityType _entityType;
    [SerializeField] protected List<GameObject> _prefabsToSpawn;
    [SerializeField] protected float _minInterval;
    [SerializeField] protected float _maxInterval; 
    [SerializeField] protected float _minInitialWaitTimeInterval;
    [SerializeField] protected float _maxInitialWaitTimeInterval;

    [SerializeField] protected int _maxEntityCount; // per spawner
    protected List<GameObject> _entityPool;
    private float _intervalTime;
    protected float _initialIntervalTime;

    // Start is called before the first frame update
    public virtual void Start()
    {
        _entityPool = InitializeObjectPool(_maxEntityCount, _prefabsToSpawn);
        _initialIntervalTime = GenerateRandomInterval(_minInitialWaitTimeInterval, _maxInitialWaitTimeInterval);
        StartCoroutine(RandomSpawn(_initialIntervalTime));
        Debug.Log("base spawner start");

    }

    public virtual List<GameObject> InitializeObjectPool(int maxEntityCount, List<GameObject> prefabsToSpawn) {
        List<GameObject> entityPool = new List<GameObject>();
        for (int i = 0; i < maxEntityCount; i++) {
            int j = Random.Range(0, prefabsToSpawn.Count);
            GameObject newObj = Instantiate(prefabsToSpawn[j], transform);
            newObj.name += newObj.GetInstanceID();
            newObj.SetActive(false);
            entityPool.Add(newObj);

        }

        return entityPool;

    }

    public IEnumerator RandomSpawn(float waitTime) {
        Debug.Log("coroutine");
        if (_entityPool != null) {
            while (GameManager.Instance.IsPlaying()) {

                yield return new WaitForSeconds(waitTime);
            
                // if (_entityPool.Count < _maxEntityCount) {
                //     int i = Random.Range(0, _prefabsToSpawn.Count);
                //     GameObject newObj = Instantiate(_prefabsToSpawn[i], transform);
                //     newObj.name += newObj.GetInstanceID();
                //     _entityPool.Add(newObj);    
                    
                    

                // } else {
                //     int randomIndex = Random.Range(0, _entityPool.Count); 
                //     _entityPool[randomIndex].SetActive(true);

                // }

                int randomIndex = Random.Range(0, _entityPool.Count); 
                _entityPool[randomIndex].SetActive(true);

                waitTime = GenerateRandomInterval(_minInterval, _maxInterval);

            }   
        }
        
        
    }

    public float GenerateRandomInterval(float minRange, float maxRange) {
        return Random.Range(minRange, maxRange);
    }
}
