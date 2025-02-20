using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyEntity", menuName = "Entities/Enemy", order = 1)]  
public class EnemyEntity : ScriptableObject
{   
    public string prefabName;
    public GameObject prefab;
    public Vector3 originalSpawner;

    public float maxMovementSpeed;
    public float minMovementSpeed;
    

}
