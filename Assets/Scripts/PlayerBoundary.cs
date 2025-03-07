using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBoundary : MonoBehaviour
{
    public static PlayerBoundary Instance {
        get;
        private set;

    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;

        }
    }

    public UnityEvent onEnemyCrossingPlayerBoundary;


    void Start() {
        // _objSphereCollider = GetComponent<SphereCollider>();

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            Debug.Log("hi im hitting the boundary");
            onEnemyCrossingPlayerBoundary.Invoke();
                       
        }
    }

    
}
