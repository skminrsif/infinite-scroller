using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryManager : MonoBehaviour
{

    private Dictionary<GameObject, Bounds> _sceneryObjects;

    public static SceneryManager Instance {
        get;
        private set;

    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            _sceneryObjects = new Dictionary<GameObject, Bounds>();
        }
    }

    public void AddSceneryObject(GameObject gameObject, Bounds bounds) {
        _sceneryObjects.Add(gameObject, bounds);
    }

    public Dictionary<GameObject, Bounds> GetSceneryObjects() {
        return _sceneryObjects;
    }

}
