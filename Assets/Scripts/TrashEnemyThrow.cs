using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashEnemyThrow : MonoBehaviour
{
    private GameObject _trashProjectile;
    private ObjectPool _trashPool;
    private GameObject _enemyCar;
    private bool _hasThrown;

    void OnEnable() {
        _hasThrown = false;
    }

    void OnDisable() {
        _hasThrown = true;
    }
    
    void Awake() {
        _enemyCar = gameObject;
        _trashPool = GetComponent<ObjectPool>();
    }

    public void ThrowTrash() {

        _trashProjectile = _trashPool.GetPooledObject();

        if (_trashProjectile != null) {
            _trashProjectile.transform.position =  _enemyCar.transform.position;
            _trashProjectile.transform.rotation = _enemyCar.transform.rotation;
            _trashProjectile.SetActive(true);
        }
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerBoundary" && !_hasThrown) {
            ThrowTrash();
            _hasThrown = true;
        }
    }

}
