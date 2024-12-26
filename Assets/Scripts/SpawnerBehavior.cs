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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomSpawn(Random.Range(_minInterval, _maxInterval)));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // StartCoroutine(RandomSpawn(Random.Range(_minInterval, _maxInterval)));
    }

    private IEnumerator RandomSpawn(float waitTime) {
        Debug.Log(waitTime);
        yield return new WaitForSeconds(waitTime);
        
        int i = Random.Range(0, _prefabsToSpawn.Count);
        Instantiate(_prefabsToSpawn[i]);

        // yield return new WaitForSeconds(waitTime);
    }
}
