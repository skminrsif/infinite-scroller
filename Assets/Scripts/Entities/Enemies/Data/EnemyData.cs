using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Entity Data/Enemy Data")]  
public class EnemyData : EntityData
{   
    public Vector3 originalSpawner;

    public float maxMovementSpeed;
    public float minMovementSpeed;
    

}
