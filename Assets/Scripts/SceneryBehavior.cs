using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryBehavior : MonoBehaviour
{

    // [SerializeField] private float _movementSpeed;
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    // private Vector3 _position;
    // private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _originalPosition = transform.position;
        _originalRotation = transform.rotation;
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     // _velocity = transform.
    // }

    // public void FixedUpdate() {
    //     Move(_movementSpeed);

    // }

    // private void Move(float speed) {
        
    // }

    // TO DO : tp back to assigned spawner once it reaches the end boundary
    private void TeleportToSpawn() {
        transform.position = _originalPosition;
        transform.rotation = _originalRotation;
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("EndBoundary")) {
            TeleportToSpawn();
            gameObject.SetActive(false);
        }
    }
}
