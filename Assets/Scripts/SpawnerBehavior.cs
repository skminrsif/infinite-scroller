using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    // public enum EntityType {
    //     Obstacle,
    //     Enemy
    // }

    // [SerializeField] private EntityType _entityType;
    [SerializeField] private List<GameObject> _prefabsToSpawn;
    [SerializeField] private float _minInterval;
    [SerializeField] private float _maxInterval; 
    [SerializeField] private float _minInitialWaitTimeInterval;
    [SerializeField] private float _maxInitialWaitTimeInterval;

    [SerializeField] private int _maxEntityCount; // per spawner
    private List<GameObject> _entityPool;

    private float _intervalTime;
    private float _initialIntervalTime;

    // Start is called before the first frame update
    void Start()
    {
        _entityPool = new List<GameObject>();
        _initialIntervalTime = GenerateRandomInterval(_minInitialWaitTimeInterval, _maxInitialWaitTimeInterval);
        StartCoroutine(RandomSpawn(_initialIntervalTime));

    }

    void Update()
    {
        
    }

    private IEnumerator RandomSpawn(float waitTime) {
        while (GameManager.Instance.IsPlaying()) {

            yield return new WaitForSeconds(waitTime);
            
            if (_entityPool.Count < _maxEntityCount) {
                int i = Random.Range(0, _prefabsToSpawn.Count);
                GameObject newObj = Instantiate(_prefabsToSpawn[i], transform);
                _entityPool.Add(newObj);    
                

            } else {
                int randomIndex = Random.Range(0, _entityPool.Count); 
                _entityPool[randomIndex].SetActive(true);

            }

            

            waitTime = GenerateRandomInterval(_minInterval, _maxInterval);

        }
        
    }

    public float GenerateRandomInterval(float minRange, float maxRange) {
        return Random.Range(minRange, maxRange);
    }
}
