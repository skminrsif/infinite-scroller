using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : SpawnerBehavior
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Awake()
    {
        // base.Awake();
    }

    public override IEnumerator RandomSpawn(float waitTime) {
            while (GameManager.Instance.IsPlaying()) {
                
                yield return new WaitForSeconds(waitTime);
                int randomIndex = Random.Range(0, _entityPool.Count); 
                _entityPool[randomIndex].SetActive(true);
                waitTime = GenerateRandomInterval(_minInterval, _maxInterval);

            }   
        
        
        
    }

}
