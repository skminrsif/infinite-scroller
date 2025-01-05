using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    public enum EntityType {
        Obstacle,
        Enemy
    }

    [SerializeField] private EntityType _entityType;
    [SerializeField] private List<GameObject> _prefabsToSpawn;
    [SerializeField] private float _minInterval;
    [SerializeField] private float _maxInterval; 

    [SerializeField] private int _maxEntityCount; // per spawner
    private List<GameObject> _entityPool;

    private float _intervalTime;

    // Start is called before the first frame update
    void Start()
    {
        _entityPool = new List<GameObject>();
        _intervalTime = GenerateRandomInterval(_minInterval, _maxInterval);
        StartCoroutine(RandomSpawn(_intervalTime));

    }

    void Update()
    {
        
    }

    private IEnumerator RandomSpawn(float waitTime) {
        while (GameManager.Instance.IsPlaying()) {
            Debug.Log(waitTime);
            Debug.Log(_entityPool.Count);

            if (_entityPool.Count < _maxEntityCount) {
                int i = Random.Range(0, _prefabsToSpawn.Count);
                GameObject newObj = Instantiate(_prefabsToSpawn[i]);
                _entityPool.Add(newObj);    

            } else {
                int randomIndex = Random.Range(0, _entityPool.Count); 
                _entityPool[randomIndex].SetActive(true);

            }

            yield return new WaitForSeconds(waitTime);

            waitTime = GenerateRandomInterval(_minInterval, _maxInterval);

        }
        
    }

    public float GenerateRandomInterval(float minRange, float maxRange) {
        return Random.Range(minRange, maxRange);
    }
}
