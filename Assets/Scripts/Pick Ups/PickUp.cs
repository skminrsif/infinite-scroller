using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUp", menuName = "PickUps", order = 2)]  
public class PickUp : ScriptableObject
{
    public string prefabName;
    public GameObject prefab;
    public Vector3[] spawnPoints; // unsure on what to do with this yet

    public float movementSpeed;
    

}
